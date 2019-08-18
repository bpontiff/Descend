using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwungWeaponCore : WeaponCore
{
    public Sprite sprite;
    public float scaleX, scaleY;
    public float startAngle;
    public float swingAngle;
    public float swingSpeed;
    public float distanceFromPlayer;
    public Vector3 RotationAxis;


    private float m_angleMoved = 0;

    public void Update()
    {
        m_angleMoved += Time.deltaTime * swingSpeed;
        transform.parent = knockbackSource.transform;
        /*
        transform.position = knockbackSource.transform.position + (transform.position - knockbackSource.transform.position).normalized * 1;
        */
        transform.RotateAround(knockbackSource.transform.position, RotationAxis, Time.deltaTime * swingSpeed);
        if (m_angleMoved >= swingAngle)
        {
            Destroy(this.gameObject);
        }
    }

    public override void UpdateDirection(ActorMovementModel.Directions prevDir, ActorMovementModel.Directions currectDirection)
    {
        if (knockbackSource == null)
            return;
        UpdateDirection(prevDir, currectDirection);
        Vector2 dist = this.transform.position - knockbackSource.transform.position;
        ActorMovementModel.Directions weaponDir = prevDir;
        float angleAdjustment = this.transform.rotation.eulerAngles.z;
        float xx = 0;
        while (weaponDir != currectDirection)
        {
            if (weaponDir >= ActorMovementModel.Directions.COUNT - 1)
            {
                weaponDir = (ActorMovementModel.Directions)0;
            }
            else
            {
                weaponDir += 1;
            }
            angleAdjustment += 90;
            xx = dist.x;
            dist.x = dist.y * -1;
            dist.y = xx;
        }
        transform.position = new Vector2( knockbackSource.transform.position.x + dist.x, knockbackSource.transform.position.y + dist.y);
        transform.rotation = Quaternion.Euler(Vector3.forward * angleAdjustment);
    }


}
