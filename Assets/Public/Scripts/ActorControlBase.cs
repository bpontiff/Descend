﻿using UnityEngine;
using System.Collections;

public class ActorControlBase : MonoBehaviour
{
    protected Actor m_Actor;

    void Awake()
    {
        m_Actor = GetComponent<Actor>();
    }

    protected Vector2 GetDiagonalDirection(Vector2 direction, float threshold)
    {
        if (Mathf.Abs(direction.x) < threshold)
        {
            direction.x = 0;
        }
        else
        {
            direction.x = Mathf.Sign(direction.x);
        }

        if (Mathf.Abs(direction.y) < threshold)
        {
            direction.y = 0;
        }
        else
        {
            direction.y = Mathf.Sign(direction.y);
        }

        return direction;
    }

    protected void SetDirection(Vector2 direction)
    {
        if (m_Actor.Movement == null)
        {
            return;
        }

        m_Actor.Movement.SetDirection(direction);
    }

    protected void OnPrimaryPressed()
    {
        Debug.Log("Primary action pressed");
    }
}