using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Public.Scripts
{
    class Player : Actor
    {

        private HeartsHealthSystem heartsHealthSystem;

        private void Awake()
        {
            this.inventoryArray = new List<InventoryItem>(1);
            Debug.Log(inventoryArray.ToString());
            Debug.Log("Awake ran");
        }

        public void SetHeartsHealthSystem(HeartsHealthSystem heartsHealthSystem)
        {
            this.heartsHealthSystem = heartsHealthSystem;
        }

        public override void Damage(int damageAmount)
        {
            heartsHealthSystem.Damage(damageAmount);
            // TODO: Check for death
        }

        public void Heal(int healAmount)
        {
            heartsHealthSystem.Heal(healAmount);
        }

        //Item Pickup and Destroy
    
        public void OnTriggerEnter(Collider other)
        {
            Destroy(other.gameObject);
        }
    }
}
