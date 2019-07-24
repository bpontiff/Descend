using UnityEngine;
using System.Collections;
using System;

public class ActorMovementModel : MonoBehaviour
{

    private Vector3 m_MovementDirection;
    private Vector3 m_FacingDirection;
    private Boolean m_SpeedOverridden = false;
    private float m_OverrideSpeed = 3.0f;


    public float movementSpeed = 3.0f;
    private int m_LastSetDirectionFrameCount;

    private Actor m_Actor;
    private Rigidbody2D m_Body;

    public Animator m_Animations;

    Vector2 m_ActiveDirection;

    void Awake()
    {
        m_Body = GetComponent<Rigidbody2D>();
        m_Actor = GetComponent<Actor>();
        m_Animations = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        //UpdatePushTime();
        UpdateDirection();
        ResetActiveDirection();
    }

    void FixedUpdate()
    {
        UpdateMovement();
    }

    private void UpdateDirection()
    {
        if (Time.frameCount == m_LastSetDirectionFrameCount)
        {
            return;
        }
        m_MovementDirection = new Vector3(m_ActiveDirection.x, m_ActiveDirection.y, 0);
        if (m_ActiveDirection != Vector2.zero)
        {
            Vector3 facingDirection = m_MovementDirection;

            if (facingDirection.x != 0 && facingDirection.y != 0)
            {
                if (facingDirection.x == m_FacingDirection.x)
                {
                    facingDirection.y = 0;
                }
                else if (facingDirection.y == m_FacingDirection.y)
                {
                    facingDirection.x = 0;
                }
                else
                {
                    facingDirection.x = 0;
                }
            }

            m_FacingDirection = facingDirection;
            m_LastSetDirectionFrameCount = Time.frameCount;

            if(m_FacingDirection.y == -1)
            {
                m_Animations.Play("MoveDown");
            }
            else if (m_FacingDirection.y == 1)
            {
                m_Animations.Play("MoveUp");
            }
            else if (m_FacingDirection.x == -1)
            {
                m_Animations.Play("MoveLeft");
            }
            else if (m_FacingDirection.x == 1)
            {
                m_Animations.Play("MoveRight");
            }
        }
    }


    private void UpdateMovement()
    {
        if (m_MovementDirection != Vector3.zero)
        {
            m_MovementDirection.Normalize();
        }

        float speed = movementSpeed;

        if (m_SpeedOverridden == true)
        {
            speed = m_OverrideSpeed;
        }

        m_Body.velocity = m_MovementDirection * speed;
    }

    void ResetActiveDirection()
    {
        m_ActiveDirection = Vector2.zero;
    }

    internal void SetDirection(Vector2 direction)
    {
        if (direction == Vector2.zero)
        {
            return;
        }
        m_ActiveDirection = direction;
    }
}
