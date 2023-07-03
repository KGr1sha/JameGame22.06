using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCamera : MonoBehaviour
{

    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        Vector3 temp = transform.position;
        temp.x = player.position.x;
        temp.y = player.position.y;

        transform.position = temp;
        if (Input.GetKeyUp(KeyCode.E))
        {
            SceneManager.LoadScene("Falling");
        }
    }
}
