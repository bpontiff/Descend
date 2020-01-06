using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupText : MonoBehaviour
{
    public Color32 color = new Color(0.8f, 0.8f, 0, 1.0f);
    public float scroll = 0.05f;  // scrolling velocity
     public float duration = 1.5f; // time to die
     public float alpha;
 
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<UnityEngine.UI.Text>().material.color = color; // set text color
        alpha = 1;

    }

    // Update is called once per frame
    void Update()
    {

        if (alpha > 0)
        {
            transform.position.Set(transform.position.x, scroll * Time.deltaTime, transform.position.z);
            //alpha -= Time.deltaTime / duration;
            //color.a  = alpha;
        }
        else
        {
            //Destroy(gameObject); // text vanished - destroy itself
        }
    }
}
