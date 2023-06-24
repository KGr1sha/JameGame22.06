using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    [SerializeField] private float speed = 5.5f;
    private int moveDir = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3 (speed * moveDir * Time.deltaTime, 0, 0));
    }


    public void SetMoveDir(int moveDirection)
    {
        moveDir = moveDirection;
        if (moveDir == 1)
        {
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            sprite.flipX = true;
        }
    }
}
