using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawn : MonoBehaviour
{
    [SerializeField] private GameObject healPackPrefab;
    [SerializeField] private float spawnRate = 25f;
    private Vector2 spawnPosition;
    private Vector2 screenBorders;
    private float spriteHeight;
    private float spriteWidth;

    private void Start()
    {
        screenBorders = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        SpriteRenderer sprite = healPackPrefab.GetComponent<SpriteRenderer>();
        spriteHeight = sprite.bounds.size.y;
        spriteWidth = sprite.bounds.size.x;
        StartCoroutine(Spawner());
    }

    private void Spawn()
    {
        SpawnPos();
        GameObject pack = Instantiate(healPackPrefab);
        pack.transform.position = spawnPosition;
    }


    private void SpawnPos()
    {
        float cordX = Random.Range(screenBorders.x * -1 + spriteWidth * 2, screenBorders.x - spriteWidth * 2);
        float cordY = screenBorders.y * -1 - spriteHeight * 2;
        spawnPosition = new Vector2(cordX, cordY);
    }



    IEnumerator Spawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            Spawn();
        }
    }

}
