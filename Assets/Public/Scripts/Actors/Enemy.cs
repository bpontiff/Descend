using System.Collections;
using UnityEngine;

namespace Assets.Public.Scripts
{
    class Enemy : Actor
    {
        public int health;
        [SerializeField] private int damageAmount = 0;

        private void Start()
        {
            health = maxHealth;
        }
        void OnCollisionEnter2D(Collision2D col)
        {
            Player player = col.gameObject.GetComponent<Player>();
            if (player != null)
            {
                // We hit the Player
                //Vector3 knockbackDir = (player.GetPosition() - transform.position).normalized;
                player.Damage(damageAmount);
            }

        }

        public override void Damage(int damageAmount)
        {
            health -= damageAmount;
            // TODO: Check for death
        }
    }
}
