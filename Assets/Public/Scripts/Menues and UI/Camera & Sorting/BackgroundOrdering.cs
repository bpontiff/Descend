using UnityEngine;
using UnityEngine.Tilemaps;

public class BackgroundOrdering : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        //Set the background tile parent to be the max negative z order
        TilemapRenderer[]
                tileRenders = GetComponentsInChildren<TilemapRenderer>();
        foreach (TilemapRenderer render in tileRenders)
        {
            render.sortingOrder = -32768;
        }
    }

}
