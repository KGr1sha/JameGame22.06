using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BobLife : MonoBehaviour
{
    private bool isHit = false;
    [SerializeField] Animator animator;
    private Score _score;
    [SerializeField] GameObject deathScreen;

    public int maxHealth;
    public int currentHealth;

    [SerializeField] TextMeshProUGUI deathScoreText;
    [SerializeField] TextMeshProUGUI deathBestScoreText;




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
        deathScoreText.text = "SCORE: " + _score.score;
        deathBestScoreText.text = "BEST SCORE: " + PlayerPrefs.GetInt("highscore");
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