using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject _pigeonSpawner;
    [SerializeField] private GameObject _stayaSpawner;
    private PigeonSpawner pigeonScript;
    private StayaSpawner stayaScript;
    [SerializeField] GameObject pigeonPrefab;
    
    
    
    private float difficulty = 1f;
    
    
    public int score;

    private void Start()
    {
        StartCoroutine(addScore());
        pigeonScript = _pigeonSpawner.GetComponent<PigeonSpawner>();
    }
    private IEnumerator addScore()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.2f);
            score++;
            scoreText.text = "SCORE: " + score;
            if (score % 20 == 0)
            {
                difficulty += .1f;
                pigeonScript.IncreaseDifficulty(difficulty);
            }
        }
    }
}
