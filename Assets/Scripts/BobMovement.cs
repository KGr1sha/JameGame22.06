using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobMovement : MonoBehaviour
{
    private float horizontal;
    private Rigidbody2D rb;
    [SerializeField] private float movespeed = 2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        rb.MovePosition(new Vector2(rb.position.x + horizontal * movespeed * Time.deltaTime, rb.position.y));
    }
}
