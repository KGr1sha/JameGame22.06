using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayaSpawner : MonoBehaviour
{
    [SerializeField] GameObject stayaPrefab;
    [SerializeField] GameObject indicatorPrefab;
    [SerializeField] float spawnRate = 5f;
    private Vector2 spawnPosition;
    private Vector2 screenBounds;
    private int _moveDirection;
    private float objectWidth;
    private float objectHeight;
    private float indicatorWidth;
    private MoveForward stayaScript;
    private int r;
    private Vector2 indicatorPos;
    private SpriteRenderer ind;
    


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
        r = Random.Range(0, 2);
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
        stayaScript = st.GetComponent<MoveForward>();
        stayaScript.SetMoveDir(_moveDirection);
        
        
        st.transform.position = spawnPosition;
        
    }


    IEnumerator Indicator()
    {
        ChoseSpawn();
        GameObject indicator = Instantiate(indicatorPrefab);
        ind = indicator.GetComponent<SpriteRenderer>();
        indicatorWidth = ind.bounds.size.x / 2;
        if (r == 0)
        {
            indicatorPos = new Vector2(spawnPosition.x + objectWidth + indicatorWidth, spawnPosition.y);
            ind.flipX = false;
        }
        if(r == 1)
        {
            indicatorPos = new Vector2(spawnPosition.x - objectWidth - indicatorWidth, spawnPosition.y);
            ind.flipX = true;
        }
        indicator.transform.position = indicatorPos;
        yield return new WaitForSeconds(1);
        Destroy(indicator);
    }

    IEnumerator StayaSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            StartCoroutine(Indicator());
            yield return new WaitForSeconds(1f);
            SpawnEnemy();
        }
    }
}
