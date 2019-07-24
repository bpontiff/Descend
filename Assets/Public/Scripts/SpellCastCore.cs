using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCastCore : WeaponCore
{
    public Projectile projectile;

    public override void PrimaryAction(Actor m_Actor)
    {
        Projectile bullet = (Projectile)Instantiate(projectile, m_Actor.transform.position + m_Actor.transform.right, m_Actor.transform.rotation);
        bullet.Source = m_Actor;
        bullet.knockbackSource = m_Actor.gameObject;
        bullet.knockbackStrength = this.knockbackStrength;
        bullet.damage = this.damage;
    }
}
