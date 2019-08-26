using System.Collections;
using UnityEngine;

namespace Assets.Public.Scripts
{
    class Enemy : Actor
    {
        [SerializeField] private int damageAmount;

        void OnTriggerEnter2D(Collider2D collider)
        {
            Player player = collider.GetComponent<Player>();
            if (player != null)
            {
                // We hit the Player
                Vector3 knockbackDir = (player.GetPosition() - transform.position).normalized;
                player.DamageKnockback(knockbackDir, 10f, damageAmount);
            }

        }
    }
}
