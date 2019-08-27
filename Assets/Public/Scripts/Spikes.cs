using Assets.Public.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private int damageAmount = 0;

    void OnTriggerEnter2D(Collider2D col)
    {
        Player player = col.GetComponent<Player>();
        if (player != null)
        {
            // We hit the Player
            //Vector3 knockbackDir = (player.GetPosition() - transform.position).normalized;
            player.Damage(damageAmount);
        }

    }
}
