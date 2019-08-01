using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwungWeaponCore : WeaponCore
{
    public float startAngle;
    public float swingAngle;
    public float swingSpeed;

    public Vector3 RotationAxis;

    private float m_angleMoved = 0;

    public void Update()
    {
        m_angleMoved += Time.deltaTime * swingSpeed;
        transform.parent = knockbackSource.transform;
        transform.position = knockbackSource.transform.position + (transform.position - knockbackSource.transform.position).normalized * 1;
        transform.RotateAround(knockbackSource.transform.position, RotationAxis, Time.deltaTime * swingSpeed);
        if(m_angleMoved >= swingAngle)
        {
            Destroy(this.gameObject);
        }
    }

    public override void PrimaryAction(Actor m_Actor)
    {
        float modifiedAngle = modifiedAngleCalc(startAngle, m_Actor) - 90;
        float myAngleInRads = (modifiedAngle * Mathf.PI) / 180;
        Vector3 startPos = new Vector3(Mathf.Cos(myAngleInRads), Mathf.Sin(myAngleInRads), 0);
        SwungWeaponCore weapon = (SwungWeaponCore)Instantiate(this, m_Actor.transform.position + startPos, Quaternion.Euler(Vector3.forward * (-90 + modifiedAngle)));
        
        weapon.knockbackSource = m_Actor.gameObject;
        weapon.Source = m_Actor;
        weapon.RotationAxis = RotationAxis;
    }
}
