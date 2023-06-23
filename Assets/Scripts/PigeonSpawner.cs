using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PigeonSpawner : MonoBehaviour
{
    [SerializeField] GameObject pigeonPrefab;
    [SerializeField] private float spawnRate = 1f;
    private Vector2 screenBounds;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(PigeonWave());
    }

    private void SpawnEnemy()
    {
        float spawnX = Random.Range(screenBounds.x * -1 + 2, screenBounds.x - 2);
        GameObject enemy = Instantiate(pigeonPrefab) as GameObject;
        enemy.transform.position = new Vector2(spawnX, screenBounds.y * -1 - 1);
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
