using UnityEngine;

public class SwungWeaponPickup : MonoBehaviour
{
    public SwungWeaponHolsterCore weaponType;

    public Sprite sprite;
    public float scaleX, scaleY;
    public float startAngle;
    public float swingAngle;
    public float swingSpeed;
    public int weaponDamage;
    public float knockbackStrength;
    public float distanceFromPlayer;
    public int numberToSpawn = 1;
    public float angleBetweenInstances;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Player")
        {
            return;
        }

        ActorControlBase controller = col.GetComponent<ActorControlBase>();
        if (controller == null)
        {
            Debug.LogWarning(col.ToString() + " does not have an actor controller base");
            return;
        }
        else
        {
            Destroy(controller.holsterInstance.gameObject);
            controller.holsterInstance = Instantiate(weaponType);
            controller.holsterInstance.transform.parent = controller.transform;
            controller.holsterInstance.UpdateWeapon(sprite, startAngle, numberToSpawn, angleBetweenInstances, scaleX, scaleY, swingAngle, swingSpeed, weaponDamage, knockbackStrength, distanceFromPlayer);
            Destroy(this.gameObject);
        }

    }
}
