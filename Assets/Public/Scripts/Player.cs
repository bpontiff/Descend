using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Public.Scripts
{
    class Player : Actor
    {
        public Image[] hearts;
        public Sprite fullHeart;
        public Sprite emptyHeart;

        void Update ()
        {
            if (health > maxHealth)
            {
                health = maxHealth;
            }

            for (int i = 0; i < hearts.Length; i++) {
                if (i < health)
                {
                    hearts[i].sprite = fullHeart;
                } else
                {
                    hearts[i].sprite = emptyHeart;
                }

                if (i < maxHealth)
                {
                    hearts[i].enabled = true;
                } else
                {
                    hearts[i].enabled = false;
                }
            }
        }
    }
}
