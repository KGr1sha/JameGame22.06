using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float parallaxEffect = 0.1f;
    private Transform cameraPos;
    private Vector3 prevPos;
    void Start()
    {
        cameraPos = Camera.main.transform;
        prevPos = cameraPos.position;
    }

    
    void Update()
    {
        Vector3 delta = cameraPos.position - prevPos;
        prevPos = cameraPos.position;

        transform.position += delta * parallaxEffect; 
    }
}
