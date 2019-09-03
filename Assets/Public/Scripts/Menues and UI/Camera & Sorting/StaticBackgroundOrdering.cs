using UnityEngine;

public class StaticBackgroundOrdering : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = -32768;
        GetComponentInChildren<SpriteRenderer>().sortingOrder = -32768;
    }
}
