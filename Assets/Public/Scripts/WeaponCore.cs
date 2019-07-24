using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponCore : DamageCore
{
    public abstract void PrimaryAction(Actor m_Actor);
}
