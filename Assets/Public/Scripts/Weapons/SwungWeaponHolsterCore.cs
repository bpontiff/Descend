using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwungWeaponHolsterCore : WeaponHolsterCore
{

    public Sprite sprite;
    public float scaleX, scaleY;
    public float startAngle;
    public float swingAngle;
    public float swingSpeed;
    public float distanceFromPlayer;
    public Vector3 RotationAxis;
    public SwungWeaponCore weaponPrefab;

    private SwungWeaponCore weaponInstance;


    public override void PrimaryAction(Actor m_Actor)
    {
        if (weaponInstance != null)
            return;
        float modifiedAngle = WeaponCore.modifiedAngleCalc(startAngle, m_Actor) - 90;
        float myAngleInRads = (modifiedAngle * Mathf.PI) / 180;
        Vector3 startPos = new Vector3(Mathf.Cos(myAngleInRads) * distanceFromPlayer, Mathf.Sin(myAngleInRads) * distanceFromPlayer, 0);
        SwungWeaponCore weapon = Instantiate(weaponPrefab, m_Actor.transform.position + startPos, Quaternion.Euler(Vector3.forward * (-90 + modifiedAngle)));

        weapon.knockbackSource = m_Actor.gameObject;
        weapon.Source = m_Actor;
        weapon.RotationAxis = RotationAxis;
        weapon.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
        weapon.GetComponent<Transform>().localScale = new Vector3(scaleX, scaleY, 1);
        weaponInstance = weapon;

        weaponInstance.sprite = this.sprite;
        weaponInstance.startAngle = this.startAngle;
        weaponInstance.scaleX = this.scaleX;
        weaponInstance.scaleY = this.scaleY;
        weaponInstance.swingAngle = this.swingAngle;
        weaponInstance.swingSpeed = this.swingSpeed;
        weaponInstance.damage = this.damage;
        weaponInstance.knockbackStrength = this.knockbackStrength;
        weaponInstance.distanceFromPlayer = this.distanceFromPlayer;
    }

    public override void UpdateDirection(ActorMovementModel.Directions prevDir, ActorMovementModel.Directions currectDirection)
    {
        if (weaponInstance == null)
            return;
        weaponInstance.UpdateDirection( prevDir,  currectDirection);
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
