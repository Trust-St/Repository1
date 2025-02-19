using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private float movingspeed = 5f;
    private Vector2 motionvector, mousedirect, mousevector;
    Rigidbody2D rigidbody2d;
    public float clickdist = 100f;
    public Camera mainCamera;
    bool mousemove;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        motionvector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        mousedirect = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousevector = new Vector2(mousedirect.x, mousedirect.y);


        if (Input.GetMouseButtonDown(0))
        {
            /*mousemove = true;
            print("click");
            print(mousevector);
            if (mousemove == true){
                if(transform.position=)
            }*/
            moveonclick();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movingspeed = 8f;
            move();
        }
        else
        {
            movingspeed = 5f;
            move();
        }
    }
        
     void move()
    {
        rigidbody2d.velocity = motionvector.normalized * movingspeed;
        motionvector = rigidbody2d.velocity;
    } 
    void moveonclick()
    {
        rigidbody2d.velocity = Vector2.MoveTowards(rigidbody2d.velocity, mousevector, 2f * Time.deltaTime);
        print("OK");
        transform.position = rigidbody2d.velocity;
    }
}
