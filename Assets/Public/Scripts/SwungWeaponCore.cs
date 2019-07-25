using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwungWeaponCore : WeaponCore
{
    public float startAngle;
    public float swingAngle;


    public Vector3 RotationAxis;

    public void Update()
    {
        transform.parent = knockbackSource.transform;
        transform.position = knockbackSource.transform.position + (transform.position - knockbackSource.transform.position).normalized * 1;
        transform.RotateAround(knockbackSource.transform.position, RotationAxis, Time.deltaTime * 200);
    }

    public override void PrimaryAction(Actor m_Actor)
    {
        SwungWeaponCore weapon = (SwungWeaponCore)Instantiate(this, m_Actor.transform.position + m_Actor.transform.right, Quaternion.Euler(Vector3.forward * -90));
        weapon.knockbackSource = m_Actor.gameObject;
        weapon.Source = m_Actor;
        weapon.RotationAxis = new Vector3 (0, 0, 1);
    }
}
