using UnityEngine;

public class SymetricShootingHolsterCore : WeaponHolsterCore
{
    public Projectile projectile;
    public float projectileSpeed;
    public float startAngle;

    [Range(1, 500)]
    public int projectileCount;
    [Range(0.1f, 180.0f)]
    public float angleBetweenShots;


    public void Update()
    {
        if (timeTillNextShot > 0)
        {
            timeTillNextShot -= Time.deltaTime;
        }
    }

    //Wrapper to check if you can shoot
    public bool CanShoot()
    {
        if (timeTillNextShot <= 0)
        {
            return true;
        }

        return false;
    }

    public override void PrimaryAction(Actor m_Actor)
    {
        if (!CanShoot())
        {
            return;
        }

        float modifiedAngle = WeaponCore.modifiedAngleCalc(startAngle, m_Actor);
        int angleMod = 1;
        int angleMultiple = 0;
        for (int i = 0; i < projectileCount; i++)
        {
            if (i % 2 == 0)
            {
                angleMod = 1;
            }
            else
            {
                angleMod = -1;
            }

            angleMultiple = ((i - 1) / 2) + 1;

            if (i == 0 || angleMultiple < 0)
            {
                angleMultiple = 0;
            }

            createProjectile(m_Actor, modifiedAngle + angleBetweenShots * angleMultiple * angleMod, projectileSpeed);
        }

        //Set the timer till the shot can be fired
        timeTillNextShot = secDelayBetweenShots;
    }


    private void createProjectile(Actor m_Actor, float angle, float speed)
    {
        float myAngleInRads = (angle * Mathf.PI) / 180;
        Vector3 startPos = new Vector3(Mathf.Cos(myAngleInRads), Mathf.Sin(myAngleInRads), 0);

        GameObject bulletObj = ObjectPooling.SharedInstance.SafeGetPooledObject("ProjectileBase");
        if (bulletObj != null)
        {
            bulletObj.SetActive(true);
            Projectile bullet = bulletObj.GetComponent<Projectile>();
            bullet.Source = m_Actor;
            bullet.setMovementDirection(startPos);
            bullet.knockbackSource = m_Actor.gameObject;
            bullet.knockbackStrength = knockbackStrength;
            bullet.damage = damage;

            bullet.transform.position = m_Actor.transform.position + startPos;
            bullet.transform.rotation = Quaternion.Euler(Vector3.forward * (-90 + angle));
        }


    }

    public override void UpdateDirection(ActorMovementModel.Directions prevDir, ActorMovementModel.Directions currectDirection)
    {
        throw new System.NotImplementedException();
    }

    public override void UpdateWeapon(Sprite sprite, float startAngle, int numberToSpawnn, float angleBetweenInstances, float scaleX, float scaleY, float swingAngle, float swingSpeed, int weaponDamage, float knockbackStrength, float distanceFromPlayer)
    {
        throw new System.NotImplementedException();
    }
}
