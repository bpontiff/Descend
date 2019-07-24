﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private Rigidbody2D m_Body;
    private DamageCore m_damangeCore;

    // Start is called before the first frame update
    void Start()
    {
        m_Body = GetComponent<Rigidbody2D>();
        m_damangeCore = GetComponent<DamageCore>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "MainCamera")
            return;
        Debug.Log("Entered Trigger");
        Debug.Log(col.gameObject.tag);
        Destroy(this.gameObject);
    }
}
