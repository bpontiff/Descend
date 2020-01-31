using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour
{
    public List<InventoryItem> inventoryArray;


    public ActorMovementModel Movement;
    public int maxHealth;
    //private SymetricShooterCore m_projectileShoorter;

    public abstract void Damage(int damageAmount);
    private void Awake()
    {
      //  m_projectileShoorter = new SymetricShooterCore();
    }

    //internal SymetricShooterCore getProjectileShooter()
    //{
    //    return m_projectileShoorter;
    //}
    [Serializable]
    public class InventoryItem
    {
        [SerializeField]
        public int itemCount;
        [SerializeField]
        public string itemName;
        [SerializeField]
        public bool isItemUsable;
    }

}
