using System;
using System.Collections;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public ActorMovementModel Movement;
    public int maxHealth;
    //private SymetricShooterCore m_projectileShoorter;

    private void Awake()
    {
      //  m_projectileShoorter = new SymetricShooterCore();
    }

    //internal SymetricShooterCore getProjectileShooter()
    //{
    //    return m_projectileShoorter;
    //}
}
