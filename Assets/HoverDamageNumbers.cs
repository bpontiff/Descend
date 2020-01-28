using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverDamageNumbers : HoverText
{
    protected float lifespan;
    public HoverDamageNumbers(string text, float xx, float yy, float scale, float lifespan) : base(text, xx, yy, scale)
    {
        this.lifespan = lifespan;
    }

    
    public void SetLifespan(float lifespan)
    {
        this.lifespan = lifespan;
    }

    private void Update()
    {
        yy += 0.05f;
        transform.position = new Vector2(xx, yy);
        //Remove time between updates
        lifespan -= Time.deltaTime;

        //Delete if no longer needed
        if (lifespan <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
