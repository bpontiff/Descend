using UnityEngine;

public class MovingSortOrdering : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        //Sort the sprite based on the location it is in the Y axis
        GetComponentInChildren<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1;
    }
}
