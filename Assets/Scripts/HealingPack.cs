using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPack : MonoBehaviour
{
    [SerializeField] private int healAmount = 1;
    [SerializeField] private float speed = 1f;

    private void Update()
    {
        transform.Translate(new Vector2(0, speed * Time.deltaTime));
        if(transform.position.y > 15) Destroy(this.gameObject);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<BobLife>().Heal(healAmount);
            Destroy(this.gameObject);
        }
    }

}
