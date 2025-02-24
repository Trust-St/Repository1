using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObj : ToolsHit
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        
    }
    public override void Hit()
    {
        Destroy(gameObject);
    }
}
