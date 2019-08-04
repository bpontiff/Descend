using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwungWeaponPickup : MonoBehaviour
{
    public SwungWeaponCore weaponType = new SwungWeaponCore();

    public Sprite sprite;
    public float scaleX, scaleY;
    public float startAngle;
    public float swingAngle;
    public float swingSpeed;
    public int weaponDamage;
    public float knockbackStrength;
    public float distanceFromPlayer;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Player")
            return;
        ActorControlBase controller = col.GetComponent<ActorControlBase>();
        if (controller == null)
            return;
        else
        {
            controller.weapon = weaponType;
            controller.weapon.UpdateWeapon(sprite, startAngle, scaleX, scaleY, swingAngle, swingSpeed, weaponDamage, knockbackStrength, distanceFromPlayer);

            //Destroy(this.gameObject);
        }
            
    }
}
