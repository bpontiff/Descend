﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponCore : DamageCore
{
    public abstract void PrimaryAction(Actor m_Actor);
    
    protected float modifiedAngleCalc(float startAngle, Actor m_Actor)
    {
        Vector2 swingDir = m_Actor.GetComponent<ActorMovementModel>().GetFacingDirection();
        float modifiedAngle = startAngle;
        if (swingDir.x == 0f && swingDir.y == 1f)
        {
            modifiedAngle = startAngle + 90;
        }
        else if (swingDir.x == -1f && swingDir.y == 0f)
        {
            modifiedAngle = startAngle + 180;
        }
        else if (swingDir.x == 0f && swingDir.y == -1f)
        {
            modifiedAngle = startAngle + 270;
        }
        else if (swingDir.x == 1f && swingDir.y == 0f)
        {
            modifiedAngle = startAngle;
        }
        return modifiedAngle;
    }

    public abstract void UpdateWeapon(Sprite sprite, float startAngle, float scaleX, float scaleY, float swingAngle, float swingSpeed, int weaponDamage, float knockbackStrength, float distanceFromPlayer);

    public abstract void UpdateDirection(ActorMovementModel.Directions prevDir, ActorMovementModel.Directions currectDirection);
}
