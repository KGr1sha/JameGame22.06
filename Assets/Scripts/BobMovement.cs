using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float movespeed = 2f;
    private Vector2 moveDirection;
    private SpriteRenderer sprite;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (moveDirection.x < 0)
        {
            sprite.flipX = true;
        }
        else
            sprite.flipX = false;
    }
    private void FixedUpdate()
    {
        rb.MovePosition((Vector2)transform.position + (moveDirection * movespeed * Time.deltaTime));
    }
}
