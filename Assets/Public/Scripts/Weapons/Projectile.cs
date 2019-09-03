using UnityEngine;

public class Projectile : DamageCore
{
    private Rigidbody2D m_Body;
    public string target;


    public float movementSpeed;
    private Vector3 m_MovementDirection = new Vector3(0, 0, 0);

    private void Awake()
    {
        m_Body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        m_Body.velocity = m_MovementDirection * movementSpeed;
    }

    public void setMovementDirection(Vector3 dir)
    {
        m_MovementDirection = dir;
    }
}
