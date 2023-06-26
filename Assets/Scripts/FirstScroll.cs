using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FirstScroll : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;
    [SerializeField] private GameObject infBG;
    void Update()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);

        if (transform.position.y >= 38.4f)
        {
            infBG.SetActive(true);
            this.gameObject.SetActive(false);
        }



    }
}
