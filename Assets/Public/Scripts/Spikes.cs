using Assets.Public.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : DamageCore
{
    private void Awake()
    {
        knockbackSource = this.gameObject;
    }
}
