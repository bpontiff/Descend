using Assets.Public.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCore : MonoBehaviour
{
    public Actor Source { get; set; }
    public int damage;
    public float knockbackStrength;
    public GameObject knockbackSource;

    public void ApplyKnockback(GameObject target)
    {
        //If knockback hits self, do nothing and return
        if (target == knockbackSource)
            return;

        //Apply to the general version
        ApplyKnockback(target, (Vector2)knockbackSource.transform.position);
    }

    public void ApplyKnockback(GameObject target, Vector2 sourceVector)
    {
        //If the target does not have a ridigbody2D to apply knockback to, return
        if (target.GetComponent<Rigidbody2D>() == null)
            return;
        //Get position of target
        Vector2 targetPosition = target.transform.position;

        //Get the direction vector of the target relative to the source of the knockback
        Vector2 directionalVector = targetPosition - sourceVector;

        //Round the highest value to always be 1, and the other number to be a decimal
        //This creates a standard value to multiply the knockback by
        float largeVal;
        if (directionalVector.x >= directionalVector.y)
            largeVal = directionalVector.x;
        else
            largeVal = directionalVector.y;

        directionalVector.x = directionalVector.x / largeVal;
        directionalVector.y = directionalVector.y / largeVal;

        //If hitting something at the same exact place as the source, do nothing
        if (directionalVector.x == 0 && directionalVector.y == 0)
            return;
       
        //
        target.gameObject.GetComponent<Rigidbody2D>().AddForce(directionalVector * knockbackStrength);
    }



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "MainCamera")
            return;
        if ("Player".Equals(col.gameObject.tag) || "Enemy".Equals(col.gameObject.tag))
        {
            if (Source is Player && "Enemy".Equals(col.gameObject.tag))
            {
                Enemy enemy = col.gameObject.GetComponent<Enemy>();
                enemy.health -= damage;
                ApplyKnockback(col.gameObject);
            } else if (Source is Enemy && "Player".Equals(col.gameObject.tag))
            {
                Player player = col.gameObject.GetComponent<Player>();
                player.Damage(damage);
                ApplyKnockback(col.gameObject);
            }
            else if ("Trap".Equals(gameObject.tag))
            {
                Actor actor = col.gameObject.GetComponent<Actor>();
                actor.Damage(damage);
                ApplyKnockback(col.gameObject);
            }
        }
    }
}
