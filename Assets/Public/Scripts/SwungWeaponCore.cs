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

    private SwungWeaponCore weaponInstance = null;

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
            weaponInstance = null;
            Destroy(this.gameObject);
        }
    }

    public override void UpdateDirection(ActorMovementModel.Directions prevDir, ActorMovementModel.Directions currectDirection)
    {
        if (weaponInstance == null && knockbackSource == null)
            return;
        if (weaponInstance != null)
        {
            weaponInstance.UpdateDirection(prevDir, currectDirection);
            return;
        }
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

    public override void PrimaryAction(Actor m_Actor)
    {
        if (weaponInstance != null)
            return;
        float modifiedAngle = modifiedAngleCalc(startAngle, m_Actor) - 90;
        float myAngleInRads = (modifiedAngle * Mathf.PI) / 180;
        Vector3 startPos = new Vector3(Mathf.Cos(myAngleInRads) * distanceFromPlayer, Mathf.Sin(myAngleInRads) * distanceFromPlayer, 0);
        SwungWeaponCore weapon = (SwungWeaponCore)Instantiate(this, m_Actor.transform.position + startPos, Quaternion.Euler(Vector3.forward * (-90 + modifiedAngle)));

        weapon.knockbackSource = m_Actor.gameObject;
        weapon.Source = m_Actor;
        weapon.RotationAxis = RotationAxis;
        weapon.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
        weapon.GetComponent<Transform>().localScale = new Vector3(scaleX, scaleY, 1);
        weaponInstance = weapon;
    }

    public override void UpdateWeapon(Sprite updatedSprite, float updatedStartAngle, float updatedScaleX, float updatedScaleY,
        float updatedSwingAngle, float updatedSwingSpeed, int updatedWeaponDamage, float updatedKnockbackStrength, float updatedDistanceFromPlayer)
    {
        this.sprite = updatedSprite;
        this.startAngle = updatedStartAngle;
        this.scaleX = updatedScaleX;
        this.scaleY = updatedScaleY;
        this.swingAngle = updatedSwingAngle;
        this.swingSpeed = updatedSwingSpeed;
        this.damage = updatedWeaponDamage;
        this.knockbackStrength = updatedKnockbackStrength;
        this.distanceFromPlayer = updatedDistanceFromPlayer;
    }

}
