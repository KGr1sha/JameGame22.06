using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PigeonSpawner : MonoBehaviour
{
    [SerializeField] GameObject pigeonPrefab;
    [SerializeField] private float spawnRate = 1f;
    private MoveForward pigeonScript;
    private Vector2 screenBounds;
    private Vector2 spawnPos;
    private int moveDir;
    

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(PigeonWave());
    }

    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(pigeonPrefab);
        ChoseSpawnPos();
        pigeonScript = enemy.GetComponent<MoveForward>();
        pigeonScript.SetMoveDir(moveDir);
        
        enemy.transform.position = spawnPos;
    }


    private void ChoseSpawnPos()
    {
        int r = Random.Range(0, 3);
        if (r == 0)
        {
            spawnPos = new Vector2(screenBounds.x * -1 - 1, Random.Range(screenBounds.y * -1, screenBounds.y / 4));
            moveDir = 1;
        }
        if (r == 1)
        {
            spawnPos = new Vector2(screenBounds.x + 1, Random.Range(screenBounds.y * -1, screenBounds.y / 4));
            moveDir = 0;
        }
        if (r == 2)
        {
            spawnPos = new Vector2(Random.Range(screenBounds.x * -1 + 1, screenBounds.x - 1), screenBounds.y * -1 - 0.5f);
            moveDir = Random.Range(0, 2);
        }
    }





    private IEnumerator PigeonWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            SpawnEnemy();
        }
    }
}
