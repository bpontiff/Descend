using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBackgroundOrdering : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = -32768;
        GetComponentInChildren<SpriteRenderer>().sortingOrder = -32768;
    }
}
