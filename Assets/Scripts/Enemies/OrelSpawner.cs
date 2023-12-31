using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrelSpawner : MonoBehaviour
{
    [SerializeField] private GameObject orelPrefab;
    [SerializeField] private GameObject indicatorPrefab;
    private SpriteRenderer orelSprite;
    private SpriteRenderer indicatorSprite;
    private float orelWidth;
    private float orelHeight;
    private float indHeight;
    private float spawnRate = 15f;
    private Vector2 screenBounds;
    private Vector2 spawnPosition;
    private int r;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
        orelSprite = orelPrefab.GetComponent<SpriteRenderer>();
        orelWidth = orelSprite.bounds.size.x / 2;
        orelHeight = orelSprite.bounds.size.y / 2;
        indicatorSprite = indicatorPrefab.GetComponent<SpriteRenderer>();
        indHeight = indicatorSprite.bounds.size.y / 2;
    }

    private IEnumerator Spawn()
    {

        GameObject enemy = Instantiate(orelPrefab);
        enemy.transform.position = spawnPosition;
        Orel enemyScript = enemy.GetComponent<Orel>();
        enemyScript.SetStartPosition(spawnPosition);
        if (r == 0)
        {
            enemy.transform.localScale = new Vector3(enemy.transform.localScale.x * -1, enemy.transform.localScale.y, enemy.transform.localScale.z);
            enemyScript.SetGoalPos(new Vector2(spawnPosition.x + orelWidth * 2, spawnPosition.y));
        }
        if(r == 1)
        {
            enemyScript.SetGoalPos(new Vector2(spawnPosition.x - orelWidth * 2, spawnPosition.y));
        }
        yield return new WaitForSeconds(2f);
        enemyScript.SetStartPosition(enemy.transform.position);
        enemyScript.SetGoalPos(spawnPosition);

        yield return new WaitForSeconds(5f);
        Destroy(enemy);
    }


    IEnumerator Indicator()
    {
        GameObject ind = Instantiate(indicatorPrefab);
        GetComponent<AudioSource>().Play();
        ChoseSpawn();
        ind.transform.position = new Vector2(spawnPosition.x * -1, screenBounds.y - indHeight);
        if (r == 0)
            ind.GetComponent<Indicator>().SetMoveDir(-1);
        else
            ind.GetComponent<Indicator>().SetMoveDir(1);
        yield return new WaitForSeconds(5f);
        Destroy(ind);

    }



    private void ChoseSpawn()
    {
        r = Random.Range(0, 2);
        if (r == 0)
        {
            spawnPosition = new Vector2(screenBounds.x * -1 - orelWidth, screenBounds.y / 2 - orelHeight / 2);
        }
        if (r == 1)
        {
            spawnPosition = new Vector2(screenBounds.x + orelWidth, screenBounds.y / 2 - orelHeight / 2);
        }
    }

    IEnumerator EagleSpawner()
    {
        while(true)
        {
            
            StartCoroutine(Indicator());
            yield return new WaitForSeconds(5f);
            StartCoroutine(Spawn());
            yield return new WaitForSeconds(spawnRate);
        }
        
    }


    public void BeginSpawn()
    {
        StartCoroutine(EagleSpawner());
    }
}
