using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomInfo
{
    public string name;

    //Location of room in relation to start room
    public int X, Y;
}

public class RoomController : MonoBehaviour
{

    //Singleton
    public static RoomController roomControlInstance;

    //The Dungeon Level/Floor name
    string dunLevelName = "Tutorial";

    //Currently loading room data
    RoomInfo curLoadRoomData;

    //The order to load thh rooms
    Queue<RoomInfo> loadRoomQueue = new Queue<RoomInfo>();

    //All loaded rooms
    public List<Room> loadedRooms = new List<Room>();

    //If a room is currently being loaded
    bool isLoadingRoom = false;

    private void Awake()
    {
        roomControlInstance = this;
    }


    public bool DoesRoomExist(int x, int y)
    {
        return loadedRooms.Find(item => item.X == x && item.Y == y) != null;
    }
}
