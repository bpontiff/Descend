using UnityEngine;

public class RemoveIntersectingWalls : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "InvisWall")
        {
            Debug.Log(col.gameObject);
            Destroy(col.gameObject);
        }
    }
}
