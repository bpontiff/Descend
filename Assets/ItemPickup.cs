using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Player")
        {
            return;
        }

        //ActorControlBase controller = col.GetComponent<ActorControlBase>();
        //if (controller == null)
        //{
        //    Debug.LogWarning(col.ToString() + " does not have an actor controller base");
        //    return;
        //}
        //else
        //{
        //    Destroy(controller.holsterInstance.gameObject);
        //    controller.holsterInstance = Instantiate(weaponType);
        //    controller.holsterInstance.transform.parent = controller.transform;
        //    controller.holsterInstance.UpdateWeapon(sprite, startAngle, numberToSpawn, angleBetweenInstances, scaleX, scaleY, swingAngle, swingSpeed, weaponDamage, knockbackStrength, distanceFromPlayer);
            Destroy(this.gameObject);
        //}

    }
}
