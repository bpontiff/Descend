using System.Collections.Generic;
using UnityEngine;

public class RemoveIntersectingWalls : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "InvisWall")
        {
            if (this.GetComponent<Door>() != null)
            {
                this.GetComponent<Door>().removedWalls.Add(col.gameObject);
                col.gameObject.SetActive(false);
            }
            else
            {
                Destroy(col.gameObject);
            }
        }
    }

}
