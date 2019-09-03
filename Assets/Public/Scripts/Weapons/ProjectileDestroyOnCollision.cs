using Assets.Public.Scripts;
using UnityEngine;

public class ProjectileDestroyOnCollision : MonoBehaviour
{
    private Rigidbody2D m_Body;
    private DamageCore m_damangeCore;

    // Start is called before the first frame update
    private void Start()
    {
        m_Body = GetComponent<Rigidbody2D>();
        m_damangeCore = GetComponent<DamageCore>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "MainCamera" || col.tag == "Background" || (tag.Equals(col.gameObject.tag)))
        {
            return;
        }

        Actor Source = GetComponent<DamageCore>().Source;
        if ((Source is Player && !("Player".Equals(col.gameObject.tag))) || (Source is Enemy && !("Enemy".Equals(col.gameObject.tag))))
        {
            gameObject.SetActive(false);
        }
    }
}
