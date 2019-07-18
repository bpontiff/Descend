using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private Rigidbody2D m_Body;

    // Start is called before the first frame update
    void Start()
    {
        m_Body = GetComponent<Rigidbody2D>();
    }


    // called when the cube hits the floor
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Enterted Trigger");
        Debug.Log(col.gameObject.tag);
        //Destroy(this.gameObject);
    }
}
