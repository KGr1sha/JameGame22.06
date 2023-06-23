using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    [SerializeField][Range(1f, 5f)] private float minSpeed = 1f;
    [SerializeField][Range(2f, 5f)] private float maxSpeed = 1f;
    private float speed;
    private int _moveDirection;
    private SpriteRenderer sprite;
    
    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed + 1);   
        _moveDirection = Random.Range(0, 2);
        sprite = GetComponent<SpriteRenderer>();
        if (_moveDirection != 0)
        {
            Flip();
        }

    }
    void Update()
    {
        if (_moveDirection == 0)
        {
            transform.Translate(new Vector2(-1 * speed * Time.deltaTime, 0));
        }
        else
        {
            transform.Translate(new Vector2(1 * speed * Time.deltaTime, 0));
        }
    }
    private void Flip()
    {
        sprite.flipX = !sprite.flipX;
    }
}
