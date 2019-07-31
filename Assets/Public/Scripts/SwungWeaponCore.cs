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

        //Need to modulo by 90, and add the division count
        float myAngleInRads = (startAngle*Mathf.PI) / 180;
        Vector3 startPos = new Vector3(Mathf.Cos(myAngleInRads) * 1, Mathf.Sin(myAngleInRads) * 1, 0);//new Vector3( 0 ,Mathf.Tan(startAngle) * -1,0);
        SwungWeaponCore weapon = (SwungWeaponCore)Instantiate(this, m_Actor.transform.position + startPos, Quaternion.Euler(Vector3.forward * (-90 + startAngle)));
        
        weapon.knockbackSource = m_Actor.gameObject;
        weapon.Source = m_Actor;
        weapon.RotationAxis = new Vector3 (0, 0, 1);
    }
}
