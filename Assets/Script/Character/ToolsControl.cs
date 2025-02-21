using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsControl : Controller
{
    //Goi ham
    Controller charactercontroller2d;
    [SerializeField] float offsetdistance = 1f;
    [SerializeField] float InteractZone = 1.2f;

    // Start is called before the first frame update
    private void Start()
    {
        charactercontroller2d = GetComponent<Controller>();
        rigidbody2d = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UseTool();
        }
    }

    private void UseTool()
    {
        Vector2 pos = rigidbody2d.position + lastmotionvector * offsetdistance; // vi tri nhan vat + vi tri nv
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, InteractZone);

        foreach (Collider2D collider in colliders)
        {
            ToolsHit hit = collider.GetComponent<ToolsHit>();
            if (hit != null) {
                hit.Hit();
                    break;
            }
        }
    }
}
