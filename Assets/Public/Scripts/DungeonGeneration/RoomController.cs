using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public static RoomController roomControlInstance;

    //The Dungeon Level/Floor name
    private readonly string dunLevelName = "Dungeon";

    //Currently loading room data
    private RoomInfo curLoadRoomData;

    //The order to load thh rooms
    private readonly Queue<RoomInfo> loadRoomQueue = new Queue<RoomInfo>();

    //All loaded rooms
    public List<Room> loadedRooms = new List<Room>();

    //If a room is currently being loaded
    private bool isLoadingRoom = false;

    private void Awake()
    {
        roomControlInstance = this;
    }

    private void Update()
    {
        UpdateRoomQueue();
    }

    private void UpdateRoomQueue()
    {
        if (isLoadingRoom || loadRoomQueue.Count == 0)
        {
            return;
        }

        curLoadRoomData = loadRoomQueue.Dequeue();
        isLoadingRoom = true;

        StartCoroutine(LoadRoomRoutine(curLoadRoomData));
    }

    private void Start()
    {
        LoadRoom("Start", 0, 0);
        LoadRoom("Start", 1, 0);
        LoadRoom("Start", -1, 0);
        LoadRoom("Start", 0, 1);
        LoadRoom("Start", 0, -1);
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
        string roomName = dunLevelName + info.name;

        AsyncOperation loadRoom = SceneManager.LoadSceneAsync(roomName, LoadSceneMode.Additive);

        while (loadRoom.isDone == false)
        {
            yield return null;
        }
    }

    public void RegisterRoom(Room room)
    {
        room.transform.position = new Vector2(
            curLoadRoomData.X * room.Width,
            curLoadRoomData.Y * room.Height
        );

        room.X = curLoadRoomData.X;
        room.Y = curLoadRoomData.Y;
        room.name = dunLevelName + "-" + curLoadRoomData.name + "_" + room.X + "," + room.Y;

        room.transform.parent = transform;

        isLoadingRoom = false;

        loadedRooms.Add(room);
    }

    public bool DoesRoomExist(int x, int y)
    {
        return loadedRooms.Find(item => item.X == x && item.Y == y) != null;
    }
}
