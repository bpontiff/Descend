using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovementBase : DamageCore
{
    private Rigidbody2D m_Body;

    public float movementSpeed = 3.0f;
    private Vector3 m_MovementDirection;

    void Awake()
    {
        m_Body = GetComponent<Rigidbody2D>();
        m_MovementDirection = new Vector3(1,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        m_Body.velocity = m_MovementDirection * movementSpeed;
    }
}
