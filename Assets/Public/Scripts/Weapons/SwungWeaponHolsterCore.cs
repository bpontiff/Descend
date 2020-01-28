using UnityEngine;

public class SwungWeaponHolsterCore : WeaponHolsterCore
{

    public Sprite sprite;
    public float scaleX, scaleY;
    public float startAngle;
    public int spawnCount;
    public float angleBetween;
    public float swingAngle;
    public float swingSpeed;
    public float distanceFromPlayer;
    public Vector3 RotationAxis;
    public SwungWeaponCore weaponPrefab;

    private SwungWeaponCore weaponInstance;


    public override void PrimaryAction(Actor m_Actor)
    {
        if (weaponInstance != null)
        {
            return;
        }

        for (int i = 0; i < spawnCount; i++)
        {

            float modifiedAngle = WeaponCore.modifiedAngleCalc(startAngle + i * angleBetween, m_Actor) - 90;
            float myAngleInRads = (modifiedAngle * Mathf.PI) / 180;
            Vector3 startPos = new Vector3(Mathf.Cos(myAngleInRads) * distanceFromPlayer, Mathf.Sin(myAngleInRads) * distanceFromPlayer, 0);
            SwungWeaponCore weapon = Instantiate(weaponPrefab, m_Actor.transform.position + startPos, Quaternion.Euler(Vector3.forward * (-90 + modifiedAngle)));

            weapon.knockbackSource = m_Actor.gameObject;
            weapon.Source = m_Actor;
            weapon.RotationAxis = RotationAxis;
            weapon.GetComponentInChildren<SpriteRenderer>().sprite = sprite;
            weapon.GetComponent<Transform>().localScale = new Vector3(scaleX, scaleY, 1);
            weaponInstance = weapon;

            weaponInstance.sprite = sprite;
            weaponInstance.startAngle = startAngle;
            weaponInstance.scaleX = scaleX;
            weaponInstance.scaleY = scaleY;
            weaponInstance.swingAngle = swingAngle;
            weaponInstance.swingSpeed = swingSpeed;
            weaponInstance.damage = damage;
            weaponInstance.knockbackStrength = knockbackStrength;
            weaponInstance.distanceFromPlayer = distanceFromPlayer;
        }
    }

    public override void UpdateDirection(ActorMovementModel.Directions prevDir, ActorMovementModel.Directions currectDirection)
    {
        if (weaponInstance == null)
        {
            return;
        }

        weaponInstance.UpdateDirection(prevDir, currectDirection);
    }

    public override void UpdateWeapon(Sprite updatedSprite, float updatedStartAngle, int updatedNumberToSpawn, float updatedAngleBetweenInstances, float updatedScaleX, float updatedScaleY,
        float updatedSwingAngle, float updatedSwingSpeed, int updatedWeaponDamage, float updatedKnockbackStrength, float updatedDistanceFromPlayer)
    {
        sprite = updatedSprite;
        startAngle = updatedStartAngle;
        spawnCount = updatedNumberToSpawn;
        angleBetween = updatedAngleBetweenInstances;
        scaleX = updatedScaleX;
        scaleY = updatedScaleY;
        swingAngle = updatedSwingAngle;
        swingSpeed = updatedSwingSpeed;
        damage = updatedWeaponDamage;
        knockbackStrength = updatedKnockbackStrength;
        distanceFromPlayer = updatedDistanceFromPlayer;
    }
}
