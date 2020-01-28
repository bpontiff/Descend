using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverText : MonoBehaviour
{
    protected string text;
    protected float xx, yy, scale;

    public HoverText(string text, float xx, float yy, float scale)
    {
        //Store the provided values
        this.text = text;
        this.xx = xx;
        this.yy = yy;
        this.scale = scale;

        //Set game object values to match provided
        GetComponent<TextMesh>().text = text;
        transform.position = new Vector2(xx,yy);
        transform.localScale.Set(scale, scale, transform.localScale.z);
    }

    public void UpdateData(string text, float xx, float yy, float scale)
    {
        //Store the provided values
        this.text = text;
        this.xx = xx;
        this.yy = yy;
        this.scale = scale;

        //Set game object values to match provided
        GetComponent<TextMesh>().text = text;
        transform.position = new Vector3(xx, yy);
        transform.localScale = new Vector2(scale, scale);
    }
}
