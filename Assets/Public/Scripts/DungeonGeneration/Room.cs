using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    //Room Dimensions and Location
    public int Width, Height, X, Y;

    public Door topDoor, leftDoor, bottomDoor, rightDoor;

    public List<Door> doors = new List<Door>();

    private bool updatedDoors = false;

    public Room(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Start is called before the first frame update
    private void Start()
    {
        //Room generation starting in a room that does not need it
        if (RoomController.roomControlInstance == null)
        {
            throw new System.Exception("Room generation started in location that does not have a RoomController");
        }

        Door[] doorsArray = GetComponentsInChildren<Door>();

        foreach(Door door in doorsArray)
        {
            doors.Add(door);
            switch(door.doorDirection)
            {
                case Door.DoorDirection.up:
                    topDoor = door;
                    break;
                case Door.DoorDirection.left:
                    leftDoor = door;
                    break;
                case Door.DoorDirection.down:
                    rightDoor = door;
                    break;
                case Door.DoorDirection.right:
                    bottomDoor = door;
                    break;
            }
        }

        RoomController.roomControlInstance.RegisterRoom(this);
    }

    private void Update()
    {
        if(name.Contains("End") && !updatedDoors)
        {
            RemoveUnconnectedDoors();
            updatedDoors = true;
        }
    }

    public void RemoveUnconnectedDoors()
    {
        foreach(Door door in doors)
        {
            if (!GetRoomInDir(door.doorDirection))
            {
                door.RemoveDoor();
            }
        }
    }

    public bool GetRoomInDir(Door.DoorDirection dir)
    {
        int roomX = X;
        int roomY = Y;
        switch (dir)
        {
            case Door.DoorDirection.up:
                roomY = Y + 1;
                break;
            case Door.DoorDirection.left:
                roomX = X - 1;
                break;
            case Door.DoorDirection.down:
                roomY = Y - 1;
                break;
            case Door.DoorDirection.right:
                roomX = X + 1;
                break;
        }
        return RoomController.roomControlInstance.DoesRoomExist(roomX, roomY);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(Width, Height));
    }

    public Vector2 GetRoomCenter()
    {
        return new Vector2(X * Width, Y * Height);
    }
}
