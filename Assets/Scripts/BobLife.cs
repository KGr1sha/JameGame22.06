using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobLife : MonoBehaviour
{
    private bool isHit = false;
    [SerializeField] Animator animator;
    private Score _score;
    [SerializeField] GameObject deathScreen;

    private void Start()
    {
        _score = GetComponent<Score>();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !isHit)
        {
            isHit = true;
            animator.SetBool("isHit", true);
            StartCoroutine(UnderHit());
        }
        else
            if (collision.gameObject.tag == "Enemy" && isHit)
            {
            Death();
            }
        if (collision.gameObject.tag == "Kluv")
        {
            Debug.Log("OREEEEEEL");
            Death();
        }
    }

    private void Death()
    {
        deathScreen.SetActive(true);
        Debug.Log("DEATH");
        Time.timeScale = 0f;

    }


    private IEnumerator UnderHit()
    {

        yield return new WaitForSeconds(4.5f);
        isHit = false;
        animator.SetBool("isHit", false);
    }


}