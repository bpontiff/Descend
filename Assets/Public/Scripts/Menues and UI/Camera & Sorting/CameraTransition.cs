using Cinemachine;
using UnityEngine;

public class CameraTransition : MonoBehaviour
{
    public GameObject cameraConfiner;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(cameraConfiner == null && col.tag.Equals("CameraConfiner"))
        {
            cameraConfiner = col.gameObject;
        }
        else if (col.tag == "Player" && col.GetComponent<RewiredControl>() == null)
        {
            throw new System.Exception("Rewired Control for player can not be found");
        }
        if (col.tag == "Player" && cameraConfiner != null)
        {
            Cinemachine.CinemachineVirtualCamera[] cameras = FindObjectsOfType<Cinemachine.CinemachineVirtualCamera>();
            foreach (Cinemachine.CinemachineVirtualCamera camera in cameras)
            {
                if (camera != null && camera.gameObject.activeSelf)
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
}
