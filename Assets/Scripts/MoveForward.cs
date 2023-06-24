using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{

    [SerializeField] public float minSpeed = 1f;
    [SerializeField] public float maxSpeed = 2f;
    [SerializeField] private bool goesUp;
    private float fallingSpeed = 1f;
    private Vector2 screenBounds;
    private float speed;
    private float baseSpeed = 3f;
    private int _moveDirection = 1;
    
    
    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        speed = Random.Range(minSpeed, maxSpeed + 1);
        if (goesUp)
            fallingSpeed = Random.Range(speed * 0.5f, speed);
        baseSpeed = speed;
        
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
        if(transform.position.y > screenBounds.y + 2 | transform.position.x < screenBounds.x * -1 - 2 | transform.position.x > screenBounds.x + 2)
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
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
    public void UpdateSpeed(float multiplier)
    {
        speed = baseSpeed * multiplier;
    }
}



