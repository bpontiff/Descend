using System;
using System.Collections;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    public ActorMovementModel Movement;
    public int maxHealth;
    //private SymetricShooterCore m_projectileShoorter;

    public abstract void Damage(int damageAmount);
    private void Awake()
    {
      //  m_projectileShoorter = new SymetricShooterCore();
    }

    //internal SymetricShooterCore getProjectileShooter()
    //{
    //    return m_projectileShoorter;
    //}
}
