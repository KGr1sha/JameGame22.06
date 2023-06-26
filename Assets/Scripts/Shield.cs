using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    [SerializeField] private float speed;


    private void Update()
    {
        transform.Translate(new Vector2(0, speed * Time.deltaTime));
        if (transform.position.y > 15)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<BobLife>().Shield();
            Destroy(this.gameObject);
        }
    }
}
