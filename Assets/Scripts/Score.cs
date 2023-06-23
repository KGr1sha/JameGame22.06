using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    public int score;

    private void Start()
    {
        StartCoroutine(addScore());
    }
    private IEnumerator addScore()
    {
        while(true)
        {
            yield return new WaitForSeconds(1f);
            score++;
            scoreText.text = "SCORE: " + score;

        }

    }
}
