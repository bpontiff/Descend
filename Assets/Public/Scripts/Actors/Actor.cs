using System;
using System.Collections;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public ActorMovementModel Movement;
    public int health;
    public int maxHealth;
    //private SymetricShooterCore m_projectileShoorter;
    public virtual void DamageKnockback(Vector3 knockbackDir, float knockbackDistance, int damageAmount)
    {
        transform.position += knockbackDir * knockbackDistance;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    private void Awake()
    {
      //  m_projectileShoorter = new SymetricShooterCore();
    }

    //internal SymetricShooterCore getProjectileShooter()
    //{
    //    return m_projectileShoorter;
    //}
}
