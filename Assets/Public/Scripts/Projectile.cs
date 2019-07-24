using Assets.Public.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : DamageCore
{
    public Actor Source { get; set; }
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if ("Player".Equals(col.gameObject.tag) || "Enemy".Equals(col.gameObject.tag))
        {
            if ((Source is Player && "Enemy".Equals(col.gameObject.tag)) || (Source is Enemy && "Player".Equals(col.gameObject.tag)))
            {
                Actor actor = col.gameObject.GetComponent<Actor>();
                actor.health -= damage;
                ApplyKnockback(col.gameObject);
            }
        }

    }
}
