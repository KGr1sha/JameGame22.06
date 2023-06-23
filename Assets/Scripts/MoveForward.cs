using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    [SerializeField][Range(1f, 5f)] private float minSpeed = 1f;
    [SerializeField][Range(2f, 5f)] private float maxSpeed = 1f;
    [SerializeField] private float fallingSpeed;
    private Vector2 screenBounds;
    private float speed;
    private int _moveDirection = 1;
    private SpriteRenderer sprite;
    
    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        speed = Random.Range(minSpeed, maxSpeed + 1);   
        
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
            transform.Translate(new Vector2(-1 * speed * Time.deltaTime, fallingSpeed * Time.deltaTime));
        }
        else
        {
            transform.Translate(new Vector2(1 * speed * Time.deltaTime, fallingSpeed * Time.deltaTime));
        }
        if(transform.position.y > screenBounds.y + 2)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetMoveDir(int moveDir)
    {
        _moveDirection = moveDir;
    }




    private void Flip()
    {
        sprite.flipX = !sprite.flipX;
    }
}
