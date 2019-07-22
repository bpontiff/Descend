using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCore : MonoBehaviour
{
    public float damage;
    public float knockbackStrength;
    public GameObject knockbackSource;

    public void ApplyKnockback(GameObject target)
    {
        ApplyKnockback(target, (Vector2)knockbackSource.transform.position);
    }

    public void ApplyKnockback(GameObject target, Vector2 sourceVector)
    {
        if (target.GetComponent<Rigidbody2D>() == null)
            return;
        //Get position of target
        Vector2 targetPosition = target.transform.position;
        Debug.Log(targetPosition);

        //Get the direction vector of the target relative to the source of the knockback
        Vector2 directionalVector = targetPosition - sourceVector;
        float largeVal;
        if (directionalVector.x >= directionalVector.y)
        {
            largeVal = directionalVector.x;
        }
        else
        {
            largeVal = directionalVector.y;
        }

        directionalVector.x = directionalVector.x / largeVal;
        directionalVector.y = directionalVector.y / largeVal;

        Debug.Log("Direction Vector " + directionalVector);

        target.gameObject.GetComponent<Rigidbody2D>().AddForce(directionalVector * knockbackStrength);
    }
}
