using Assets.Public.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class CameraInitlizer : MonoBehaviour
{
    public List<Cinemachine.CinemachineVirtualCamera> playerCameras;
    public List<CameraTransition> doorways;

    private void Awake()
    {
        GameObject[] gos = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject go in gos)
        {
            if (go.GetComponent<Player>() != null)
            {
                playerCameras[go.GetComponent<RewiredControl>().playerId].Follow = go.transform;
            }
        }
        foreach(CameraTransition door in doorways)
        {
            door.cameraData = this;
        }
    }

    private void  Trigger2d(Collider2D col)
    {
        if (col.GetComponent<CameraTransition>() != null)
            col.GetComponent<CameraTransition>().cameraData = this;
    }
}
