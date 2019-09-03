using Assets.Public.Scripts;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    [SerializeField] private readonly int healAmount = 0;

    private void OnTriggerEnter2D(Collider2D col)
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
