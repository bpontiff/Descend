using Assets.Public.Scripts;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    public GameObject cameraConfiner;

    private void Awake()
    {
        cameraConfiner = FindClosestConfiner();
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (cameraConfiner == null && col.GetComponent<RewiredControl>() == null) {
            throw new System.Exception("Camera Confiner for level does not exist or Rewired Control for player can not be found");
        }
        if (col.tag == "Player")
        {
            Cinemachine.CinemachineVirtualCamera[] cameras = FindObjectsOfType<Cinemachine.CinemachineVirtualCamera>();
            foreach(Cinemachine.CinemachineVirtualCamera camera in cameras)
            {
                if (camera.Follow == col.transform)
                {
                    camera.gameObject.GetComponent<CinemachineConfiner>().m_BoundingShape2D = cameraConfiner.GetComponent<PolygonCollider2D>();
                    camera.gameObject.GetComponent<CinemachineConfiner>().InvalidatePathCache();
                }
            }
        }
    }
}
