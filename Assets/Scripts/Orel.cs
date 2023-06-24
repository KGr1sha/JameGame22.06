using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orel : MonoBehaviour
{
    [SerializeField] private Vector2 goalPosition;
    [SerializeField] private AnimationCurve curve;
    private Vector2 startPosition;
    private float target = 1f;
    private float current = 0f;
    private float speed = 0.8f;


    private void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {

        current = Mathf.MoveTowards(current, target, speed * Time.deltaTime);
        
        transform.position = Vector2.Lerp(startPosition, goalPosition, curve.Evaluate(current));
    }


    public void SetStartPosition(Vector2 startPos)
    {
        startPosition = startPos;
    }

    public void SetGoalPos(Vector2 goalPos)
    {
        goalPosition = goalPos;
        current = 0;
    }
    
}
