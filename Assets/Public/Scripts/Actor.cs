using System.Collections;
using UnityEngine;

public class Actor : MonoBehaviour
{
    public ActorMovementModel Movement;
    public int health;
    public int maxHealth;

    public virtual void DamageKnockback(Vector3 knockbackDir, float knockbackDistance, int damageAmount)
    {
        transform.position += knockbackDir * knockbackDistance;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
