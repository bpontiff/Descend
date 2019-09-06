using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public enum DoorDirection
    {
        up, left, down, right
    }

    public DoorDirection doorDirection;

    public List<GameObject> removedWalls;

    public void RemoveDoor()
    {
        foreach (GameObject obj in removedWalls)
        {
            obj.SetActive(true);
        }
        this.gameObject.SetActive(false);
    }
}
    