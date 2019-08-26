using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Public.Scripts
{
    class Player : Actor
    {
        private HeartsHealthSystem heartsHealthSystem;

        private void Start()
        {
            HeartsHealthSystem heartsHealthSystem = new HeartsHealthSystem(maxHealth);
            heartsHealthUI.SetHeartsHealthSystem(heartsHealthSystem);
        }

        public void SetHeartsHealthSystem(HeartsHealthSystem heartsHealthSystem)
        {
            this.heartsHealthSystem = heartsHealthSystem;

            Vector2 heartAnchoredPosition = new Vector2(0, 0);
            foreach (HeartsHealthSystem.Heart heart in heartsHealthSystem.GetHearts())
            {
                CreateHeartImage(heartAnchoredPosition).SetHeartFragments(heart.GetFragments());
                heartAnchoredPosition += new Vector2(20, 0);
            }

            heartsHealthSystem.OnDamaged += HeartsHealthSystem_OnDamaged;
            heartsHealthSystem.OnHealed += HeartsHealthSystem_OnHealed;
            heartsHealthSystem.OnDead += HeartsHealthSystem_OnDead;
        }

        public override void DamageKnockback(Vector3 knockbackDir, float knockbackDistance, int damageAmount)
        {
            base.DamageKnockback(knockbackDir, knockbackDistance, damageAmount);
            heartsHealthUI.GetHeartsHealthSystem().Damage(damageAmount);
        }
    }
}
