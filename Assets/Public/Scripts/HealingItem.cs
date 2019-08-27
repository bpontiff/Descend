using Assets.Public.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    [SerializeField] private int healAmount;

    void OnTriggerEnter2D(Collider2D col)
    {
        Player player = col.GetComponent<Player>();
        if (player != null)
        {
            // We heal the Player
            player.Heal(healAmount);
            //Destroy(gameObject);
        }

    }
}
