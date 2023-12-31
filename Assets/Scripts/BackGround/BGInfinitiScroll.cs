using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGInfinitiScroll : MonoBehaviour
{
    [SerializeField] private float speed;
    private Sprite sprite;
    private float textureSizeY;
    private Camera _camera;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureSizeY = texture.height / sprite.pixelsPerUnit;
        _camera = Camera.main;
    }


    void Update()
    {
        transform.Translate(new Vector2(0, speed * Time.deltaTime));
        if(transform.position.y - _camera.transform.position.y > textureSizeY * 4.8f)
        {
            transform.position = new Vector2(_camera.transform.position.x, _camera.transform.position.y);
        }  
    }
}
