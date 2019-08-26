using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponHolsterCore : MonoBehaviour
{
    public Actor Source { get; set; }
    public int damage;
    public float knockbackStrength;
    public GameObject knockbackSource;

    public float secDelayBetweenShots;
    public float timeTillNextShot = 0;


    public abstract void PrimaryAction(Actor m_Actor);

    public abstract void UpdateWeapon(Sprite sprite, float startAngle, float scaleX, float scaleY, float swingAngle, float swingSpeed, int weaponDamage, float knockbackStrength, float distanceFromPlayer);
    public abstract void UpdateDirection(ActorMovementModel.Directions prevDir, ActorMovementModel.Directions currectDirection);
}
