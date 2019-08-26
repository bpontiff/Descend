using Assets.Public.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    public CameraInitlizer cameraData = null;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (cameraData == null && col.GetComponent<RewiredControl>() == null)
            return;
        int playerId = col.GetComponent<RewiredControl>().playerId;

        if(cameraData.playerCameras[playerId] == null)
        {
            Debug.LogError("Room Camera on " + this + " is null. Camera transition failed.");
            return;
        }
        else if (cameraData.playerCameras[playerId].Priority == 10) 
        {
            return;
        }
        else if (col.tag == "Player")
        {
            Cinemachine.CinemachineVirtualCamera[] cameras = FindObjectsOfType<Cinemachine.CinemachineVirtualCamera>();
            foreach(Cinemachine.CinemachineVirtualCamera camera in cameras)
            {
                if (camera.Priority == 10)
                { 
                    if (camera.Follow == col.transform)
                    {
                        //Sets current camera priority to 0 and new camera priority to 10
                        camera.Priority = 0;
                        cameraData.playerCameras[playerId].Priority = 10;
                    }
                }
            }
        }

    }
}
