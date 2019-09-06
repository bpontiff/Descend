using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Public.Scripts
{
    class Player : Actor
    {
        private HeartsHealthSystem heartsHealthSystem;


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
    }
}
