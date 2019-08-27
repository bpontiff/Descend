using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartsHealthSystem
{
    public const int MAX_FRAGMENT_AMOUNT = 4;
    public event EventHandler OnDamaged;
    public event EventHandler OnHealed;
    public event EventHandler OnDead;

    private List<Heart> hearts;

    public HeartsHealthSystem(int heartAmount)
    {
        hearts = new List<Heart>();
        for (int i = 0; i < heartAmount; i++)
        {
            this.hearts.Add(new Heart(4));
        }
    }

    public List<Heart> GetHearts()
    {
        return this.hearts;
    }

    public void Damage(int damageAmount)
    {
        // Cycle through all hearts starting from the end
        for (int i = hearts.Count - 1; i >= 0; i--)
        {
            Heart heart = hearts[i];
            // Test if this heart can absorb damageAmount
            if (damageAmount > heart.GetFragments())
            {
                // Heart cannot absorb full damageAmount, damage heart and keep going to next heart
                damageAmount -= heart.GetFragments();
                heart.Damage(heart.GetFragments());
            } else
            {
                // Heart can absorb full damageAmount, absorb and break out of the cycle
                heart.Damage(damageAmount);
                break;
            }
        }

        if (OnDamaged != null)
        {
            OnDamaged(this, EventArgs.Empty);
        }

        if (IsDead() && OnDead != null)
        {
            OnDead(this, EventArgs.Empty);
        }
    }

    public void Heal(int healAmount)
    {
        // Cycle through all hearts starting from the beginning
        foreach(Heart heart in hearts)
        {
            int missingFragments = MAX_FRAGMENT_AMOUNT - heart.GetFragments();
            // Test if this heart can absorb healAmount
            if (healAmount > missingFragments)
            {
                // Heart cannot absorb full healAmount, heal heart and keep going to next heart
                healAmount -= missingFragments;
                heart.Heal(missingFragments);
            } else
            {
                // Heart can absorb full healAmount, absorb and break out of the cycle
                heart.Heal(healAmount);
                break;
            }
        }

        if (OnHealed != null)
        {
            OnHealed(this, EventArgs.Empty);
        }
    }

    public bool IsDead()
    {
        return hearts[0].GetFragments() == 0;
    }

    // represent a single heart
    public class Heart
    {
        private int fragments;

        public Heart(int fragments)
        {
            this.fragments = fragments;
        }

        public int GetFragments()
        {
            return this.fragments;
        }

        public void SetFragments(int fragments)
        {
            this.fragments = fragments;
        }

        public void Damage (int damageAmount)
        {
            if (damageAmount >= fragments)
            {
                fragments = 0;
            } else
            {
                fragments -= damageAmount;
            }
        }

        public void Heal (int healAmount)
        {
            if (fragments + healAmount > MAX_FRAGMENT_AMOUNT)
            {
                fragments = MAX_FRAGMENT_AMOUNT;
            } else
            {
                fragments += healAmount;
            }
        }
    }
}
