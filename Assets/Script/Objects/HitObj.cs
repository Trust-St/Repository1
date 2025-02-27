using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitObj : ToolsHit
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] int dropCount = 1;
    [SerializeField] GameObject Pickupdrops;
    [SerializeField] float spread = 2f;

    void Start()
    {

    }
    public override void Hit()
    {
        while (dropCount > 0)
        {
            dropCount--;
            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2; //lay vi tri gan dung cua vat the bi pha

            GameObject go = Instantiate(Pickupdrops);
            go.transform.position = position;   
        }

        Destroy(gameObject);    
    }
}
