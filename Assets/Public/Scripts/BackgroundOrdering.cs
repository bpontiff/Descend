using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BackgroundOrdering : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Set the background tile parent to be the max negative z order
        GetComponentInChildren<TilemapRenderer>().sortingOrder = -32768;
    }
}
