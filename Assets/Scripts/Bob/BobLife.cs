using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class BobLife : MonoBehaviour
{
    [SerializeField] private UnityEvent OnPlayerHit;
    [SerializeField] private UnityEvent OnPlayerHeal;

    private bool isHit = false;
    [SerializeField] Animator animator;
    private Score _score;
    [SerializeField] GameObject deathScreen;

    public int maxHealth = 3;
    public int currentHealth = 3;

    [SerializeField] TextMeshProUGUI deathScoreText;
    [SerializeField] TextMeshProUGUI deathBestScoreText;

    [SerializeField] private GameObject musicManagerObj;

    [SerializeField] private GameObject shieldPrefab;
    [SerializeField] private float shieldDuration;
    private GameObject shield;
    private bool shielded = false;
    


    private void Start()
    {
        _score = GetComponent<Score>();
        currentHealth = maxHealth;
    }

    private void Death()
    {
        musicManagerObj.GetComponent<Music>().StopMusic();
        deathScreen.SetActive(true);
        deathScoreText.text = "SCORE: " + _score.score;
        deathBestScoreText.text = "BEST SCORE: " + PlayerPrefs.GetInt("highscore");
        Time.timeScale = 0f;

    }

    public void Shield()
    {
        shielded = true;
        shield = Instantiate(shieldPrefab);
        shield.transform.position = transform.position;
        shield.transform.SetParent(this.gameObject.transform);
        
        StartCoroutine(UnderShield());
    }


    IEnumerator UnderShield()
    {
        yield return new WaitForSeconds(shieldDuration);
        shielded = false;
        Destroy(shield);
    }



    public void Heal(int amount)
    {
        if (currentHealth < maxHealth) currentHealth += amount;
        OnPlayerHeal.Invoke();
    }



    public void TakeDamage(int amount)
    {
        if (!isHit && !shielded)
        {
            isHit = true;
            animator.SetBool("isHit", true);
            StartCoroutine(UnderHit());
            currentHealth -= amount;
            OnPlayerHit.Invoke();
        }


        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Death();
        }
    }

    private IEnumerator UnderHit()
    {

        yield return new WaitForSeconds(4.5f);
        isHit = false;
        animator.SetBool("isHit", false);
    }
}