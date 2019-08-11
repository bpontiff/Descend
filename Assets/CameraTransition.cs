using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera roomCameraP1;
    public Cinemachine.CinemachineVirtualCamera roomCameraP2;
    public Cinemachine.CinemachineVirtualCamera roomCameraP3;
    public Cinemachine.CinemachineVirtualCamera roomCameraP4;
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.GetComponent<RewiredControl>() == null)
        {
            return;
        }
        int playerId = col.GetComponent<RewiredControl>().playerId;

        if ((playerId == 0 && roomCameraP1 == null) ||
            (playerId == 1 && roomCameraP2 == null) ||
            (playerId == 2 && roomCameraP3 == null) ||
            (playerId == 3 && roomCameraP4 == null))
        {
            Debug.LogError("Room Camera on " + this + " is null. Camera transition failed.");
            return;
        }
        else if((playerId == 0 && roomCameraP1.Priority == 10) ||
            (playerId == 1 && roomCameraP2.Priority == 10) ||
            (playerId == 2 && roomCameraP3.Priority == 10) ||
            (playerId == 3 && roomCameraP4.Priority == 10))
        {
            return;
        }
        else if (col.tag == "Player")
        {
            Cinemachine.CinemachineVirtualCamera[] cameras = FindObjectsOfType<Cinemachine.CinemachineVirtualCamera>();
            foreach(Cinemachine.CinemachineVirtualCamera camera in cameras) {
                if(camera.Priority == 10)
                {
                    if(camera.Follow == col)
                    {
                        camera.Priority = 0;
                        if (playerId == 0) roomCameraP1.Priority = 10;
                        if (playerId == 1) roomCameraP2.Priority = 10;
                        if (playerId == 2) roomCameraP3.Priority = 10;
                        if (playerId == 3) roomCameraP4.Priority = 10;

                    }
                }
            }
        }

    }
}
