using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCastCore : WeaponCore
{
    public Projectile projectile;

    public override void PrimaryAction(Actor m_Actor)
    {
        float modifiedAngle = modifiedAngleCalc(0, m_Actor);

        float myAngleInRads = (modifiedAngle * Mathf.PI) / 180;
        Vector3 startPos = new Vector3(Mathf.Cos(myAngleInRads), Mathf.Sin(myAngleInRads), 0);
        Projectile bullet = (Projectile)Instantiate(projectile, m_Actor.transform.position + startPos, Quaternion.Euler(Vector3.forward * (-90 + modifiedAngle)));
        bullet.Source = m_Actor;
        bullet.setMovementDirection(startPos);
        bullet.knockbackSource = m_Actor.gameObject;
        bullet.knockbackStrength = this.knockbackStrength;
        bullet.damage = this.damage;
    }
}
