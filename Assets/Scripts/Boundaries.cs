using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        objectWidth = sprite.bounds.size.x / 2;
        objectHeight = sprite.bounds.size.y / 2;
    }

    private void LateUpdate()
    {
        Vector3 viewpos = transform.position;
        viewpos.x = Mathf.Clamp(viewpos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewpos.y = Mathf.Clamp(viewpos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        
        transform.position = viewpos;
    }
}
