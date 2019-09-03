using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveIntersectingWalls : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "InvisWall")
        {
            Debug.Log(col.gameObject);
            Destroy(col.gameObject);
        }
    }
}
