using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{

    [Header("Character movement stats")]
    [SerializeField] private float movespeed = 5f;

    private CharacterController characterController;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void MoveCharacter(Vector2 moveDirection)
    {
        characterController.Move(moveDirection * Time.deltaTime * movespeed);
    }

}
