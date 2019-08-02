using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymetricShooterCore : WeaponCore
{
    public Projectile projectile;
    public float projectileSpeed;
    public float startAngle;
    [Range(1,500)]
    public int projectileCount;
    [Range(0.1f, 180.0f)]
    public float angleBetweenShots;

    public override void PrimaryAction(Actor m_Actor)
    {
        float modifiedAngle = modifiedAngleCalc(startAngle, m_Actor);
        int angleMod = 1;
        int angleMultiple = 0;
        for (int i = 0; i < projectileCount; i++)
        {
            if (i % 2 == 0)
                angleMod = 1;
            else
                angleMod = -1;
            angleMultiple = ((i-1) / 2) + 1;

            if (i == 0 || angleMultiple < 0)
                angleMultiple = 0;

            createProjectile(m_Actor, modifiedAngle + angleBetweenShots * angleMultiple * angleMod, projectileSpeed);
        }
    }

    private void createProjectile(Actor m_Actor, float angle, float speed)
    {
        float myAngleInRads = (angle * Mathf.PI) / 180;
        Vector3 startPos = new Vector3(Mathf.Cos(myAngleInRads), Mathf.Sin(myAngleInRads), 0);
        Projectile bullet = (Projectile)Instantiate(projectile, m_Actor.transform.position + startPos, Quaternion.Euler(Vector3.forward * (-90 + angle)));
        bullet.Source = m_Actor;
        bullet.setMovementDirection(startPos);
        bullet.knockbackSource = m_Actor.gameObject;
        bullet.knockbackStrength = this.knockbackStrength;
        bullet.damage = this.damage;
    }
}
