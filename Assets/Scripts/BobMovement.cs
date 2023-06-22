using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float movespeed = 2f;
    
    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        
    }
}
