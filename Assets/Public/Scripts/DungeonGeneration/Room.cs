using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    //Room Dimensions and Location
    public int Width, Height, X, Y;

    // Start is called before the first frame update
    void Start()
    {
        //Room generation starting in a room that does not need it
        if (RoomController.roomControlInstance == null)
        {
            throw new System.Exception("Room generation started in location that does not have a RoomController");
            return;
        }
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
