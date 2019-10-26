using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class RoomInfo
{
    public string name;

    //Location of room in relation to start room
    public int X, Y;

    public RoomInfo()
    { }

    public RoomInfo(string name, int x, int y)
    {
        this.name = name;
        X = x;
        Y = y;
    }
}

public class RoomController : MonoBehaviour
{

    //Singleton
    public static RoomController instance;
    
    //The Dungeon Level/Floor name
    public string dungeonLevelName { get; set; }

    //Currently loading room data
    private RoomInfo curLoadRoomData;

    //The order to load thh rooms
    private readonly Queue<RoomInfo> loadRoomQueue = new Queue<RoomInfo>();

    //All loaded rooms
    public List<Room> loadedRooms = new List<Room>();

    //If a room is currently being loaded
    private bool isLoadingRoom, spawnedBossRoom, updatedRooms = false;
    
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        UpdateRoomQueue();
    }

    private void UpdateRoomQueue()
    {
        if (isLoadingRoom)
        {
            return;
        }

        if (loadRoomQueue.Count == 0)
        {
            if (!spawnedBossRoom)
            {
                spawnedBossRoom = true;
                StartCoroutine(SpawnBossRoom());
            }
            else if (spawnedBossRoom && !updatedRooms)
            {
                foreach (Room room in loadedRooms)
                {
                    room.RemoveUnconnectedDoors();
                }
                updatedRooms = true;
            }
            return;
        }

        curLoadRoomData = loadRoomQueue.Dequeue();
        isLoadingRoom = true;

        StartCoroutine(LoadRoomRoutine(curLoadRoomData));
    }

    public void LoadRoom(string name, int x, int y)
    {
        if (DoesRoomExist(x, y))
        {
            return;
        }
        //Create a new room info with the provided data
        RoomInfo newRoomData = new RoomInfo(name, x, y);

        loadRoomQueue.Enqueue(newRoomData);
    }

    private IEnumerator LoadRoomRoutine(RoomInfo info)
    {
        string roomName = dungeonLevelName + info.name;

        AsyncOperation loadRoom = SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);

        while (loadRoom.isDone == false)
        {
            yield return null;
        }
    }

    public void RegisterRoom(Room room)
    {
        //If a room already exists stop creating this room
        if (DoesRoomExist(curLoadRoomData.X, curLoadRoomData.Y))
        {
            Destroy(room.gameObject);
            isLoadingRoom = false;
            return;
        }

        //Spawning a room
        room.transform.position = new Vector2(
            curLoadRoomData.X * room.Width,
            curLoadRoomData.Y * room.Height
        );


        room.X = curLoadRoomData.X;
        room.Y = curLoadRoomData.Y;
        room.name = dungeonLevelName + "-" + curLoadRoomData.name + "_" + room.X + "," + room.Y;

        room.transform.parent = transform;

        isLoadingRoom = false;

        if (loadedRooms.Count == 0)
        {
            //Setyo the virtual cameras bounding shape info for the first room
            Cinemachine.CinemachineVirtualCamera[] cameras = FindObjectsOfType<Cinemachine.CinemachineVirtualCamera>();
            foreach (Cinemachine.CinemachineVirtualCamera camera in cameras)
            {
                if (camera != null)
                {
                    PolygonCollider2D col = FindClosestConfiner().GetComponent<PolygonCollider2D>();
                    CinemachineConfiner conf = camera.GetComponent<CinemachineConfiner>();
                    conf.m_BoundingShape2D = col;
                }
            }
        }

        loadedRooms.Add(room);

    }

    IEnumerator SpawnBossRoom()
    {
        yield return new WaitForSeconds(0.5f);
        if(loadRoomQueue.Count == 0)
        {
            Room bossRoom = loadedRooms[loadedRooms.Count - 1];
            Room tempRoom = new Room(bossRoom.X, bossRoom.Y);
            Destroy(bossRoom.gameObject);
            var roomToRemove = loadedRooms.Single(r => r.X == tempRoom.X && r.Y == tempRoom.Y);
            loadedRooms.Remove(roomToRemove);
            LoadRoom("End", tempRoom.X, tempRoom.Y);
        }
    }


    public GameObject FindClosestConfiner()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("CameraConfiner");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }


    public bool DoesRoomExist(int x, int y)
    {
        return loadedRooms.Find(item => item.X == x && item.Y == y) != null;
    }

    internal Room FindRoom(int x, int y)
    {
        return loadedRooms.Find(item => item.X == x && item.Y == y); ;
    }
}
