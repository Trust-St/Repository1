using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItems : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 10f;
    [SerializeField] float pickupzone = 1.5f;
    [SerializeField] float ttl = 10f;
    private bool isMouse = false;
    private bool isClick = false;
    public Texture2D hoverCursor;// con tro chuot nhan manh
    private Texture2D defaultCursor;// tro chuot mac dinh

    private void Awake()
    {
        player = GameManager.Instance.player.transform;
    }
    private void Start()
    {
        defaultCursor = CursorTexture();
    }
    private void Update()
    {
        ttl -= Time.deltaTime;
        if(ttl < 0)
        {
            Destroy(gameObject);
        }
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > pickupzone)
        {
            OnMouseExit();
            isClick = false;
            return;
            
        }

        if (distance <= pickupzone)
        {
            OnMouseEnter();
            if (Input.GetMouseButtonDown(0))
            {
                isClick = true;
            }
            if (isMouse && isClick)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }

        if (distance < 0.1f && isClick)
        {
            Destroy(gameObject);
            isClick = false;
        }

    }

    private Texture2D CursorTexture()
    {
        return null;
    }
    public void OnMouseEnter()
    {
        isMouse = true;
        if (hoverCursor != null)
        {
            Cursor.SetCursor(hoverCursor, Vector2.zero, CursorMode.Auto);
        }
    }
    public void OnMouseExit()
    {
        isMouse = false;
        Cursor.SetCursor(defaultCursor,Vector2.zero,CursorMode.Auto);
    }
}
