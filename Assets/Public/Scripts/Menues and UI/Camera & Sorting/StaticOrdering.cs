using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticOrdering : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Sort the sprite based on the location it is in the Y axis
        GetComponentInChildren<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
    }
}
