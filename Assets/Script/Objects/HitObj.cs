using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObj : ToolsHit
{
    private SpriteRenderer spriteRenderer;

    void start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public override void Hit()
    {
        if (spriteRenderer != null)
        {
            Destroy(gameObject);
        }
    }
}
