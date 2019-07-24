using System.Collections;
using UnityEngine;

namespace Assets.Public.Scripts
{
    class Enemy : Actor
    {
        void OnCollisionEnter2D(Collision2D col)
        {
            if ("Player".Equals(col.gameObject.tag))
            {
                    Player player = col.gameObject.GetComponent<Player>();
                    player.health -= 1; // TODO: enemies need weapons to attack with so this is temporary. 
            }

        }

    }
}
