using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;




    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject _pigeonSpawner;
    [SerializeField] private GameObject _stayaSpawner;
    private PigeonSpawner pigeonScript;
    private StayaSpawner stayaScript;
    private float highscore;
    
    
    
    private float difficulty = 1f;
    
    
    public int score;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(addScore());
        pigeonScript = _pigeonSpawner.GetComponent<PigeonSpawner>();
        stayaScript = _stayaSpawner.GetComponent <StayaSpawner>();
        score = 0;
        highscore = PlayerPrefs.GetInt("highscore");
        Debug.Log(highscore);
    }
    private IEnumerator addScore()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.2f);
            score++;
            scoreText.text = "SCORE: " + score;

            if(score > highscore) PlayerPrefs.SetInt("highscore", score);
            if (score % 50 == 0)
            {
                difficulty += .1f;
                pigeonScript.IncreaseDifficulty(difficulty);
                stayaScript.IncreaseDifficulty();
            }
        }
    }
}
