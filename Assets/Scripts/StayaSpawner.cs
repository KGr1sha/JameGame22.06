using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayaSpawner : MonoBehaviour
{
    [SerializeField] GameObject stayaPrefab;
    [SerializeField] float spawnRate = 5f;
    private Vector2 spawnPosition;
    private Vector2 screenBounds;
    private int _moveDirection;
    private float objectWidth;
    private float objectHeight;
    private MoveForward stayaScript;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        SpriteRenderer sprite = stayaPrefab.GetComponent<SpriteRenderer>();
        objectWidth = sprite.bounds.size.x / 2;
        objectHeight = sprite.bounds.size.y / 2;
        StartCoroutine(StayaSpawn());
    }
    void ChoseSpawn()
    {
        int r = Random.Range(0, 2);
        if (r == 0)
        {
            spawnPosition = new Vector2(screenBounds.x * -1 - objectWidth, Random.Range(screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight));
            _moveDirection = 1;
        }
        else
        {
            spawnPosition = new Vector2(screenBounds.x + objectWidth, Random.Range(screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight));
            _moveDirection = 0;
        }
    }
    


    void SpawnEnemy()
    {
        GameObject st = Instantiate(stayaPrefab);
        ChoseSpawn();
        stayaScript = st.GetComponent<MoveForward>();
        stayaScript.SetMoveDir(_moveDirection);
        st.transform.position = spawnPosition;
        
    }



    IEnumerator StayaSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            SpawnEnemy();
        }
    }
}
