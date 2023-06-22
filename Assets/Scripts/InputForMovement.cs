using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputForMovement : MonoBehaviour
{
    [SerializeField] private CharacterMove charMove;

    private float horizontal;

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        charMove.MoveCharacter(new Vector2(horizontal, 0).normalized);

    }

}


