using System.Collections;
using UnityEngine;

namespace Assets.Public.Scripts
{
    class TestDummy : Actor
    {
        public int health;
        [SerializeField] private int damageAmount = 0;
        public Transform damageText;

        private void Start()
        {
            health = maxHealth;
        }
        void OnCollisionEnter2D(Collision2D col)
        {
            Player player = col.gameObject.GetComponent<Player>();
            if (player != null)
            {
                // We hit the Player
                ;
            }

        }

        public override void Damage(int damageAmount)
        {
            health -= damageAmount;
            //TODO Enemy Death
                if (health <= 0)
                {
                    GameObject drop = ObjectPooling.SharedInstance.SafeGetPooledObject("ItemDrop");
                    Destroy(this.gameObject);
                } 
            GameObject gameObject = ObjectPooling.SharedInstance.SafeGetPooledObject("DamageNumber");
            if (gameObject != null) {
                gameObject.SetActive(true);
                gameObject.transform.position = this.transform.position;
                HoverDamageNumbers damageNumbers = gameObject.GetComponent<HoverDamageNumbers>();
                damageNumbers.UpdateData(damageAmount.ToString(), this.transform.position.x, this.transform.position.y, 0.25f);
                damageNumbers.SetLifespan(3);
            }
        }
    }
}
