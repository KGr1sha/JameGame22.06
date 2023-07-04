using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawn : MonoBehaviour
{
    [SerializeField] private GameObject healPackPrefab;
    [SerializeField] private GameObject shieldPackPrefab;
    [SerializeField] private GameObject shieldPrefab;

    [SerializeField] private GameObject player;
    [SerializeField] private float spawnRate = 25f;
    private Vector2 spawnPosition;
    private Vector2 screenBorders;
    private float spriteHeight;
    private float spriteWidth;
    private string powerUp;

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
        GameObject pack;
        ChosePowerUp();
        SpawnPos();
        if (powerUp == "heal")
        {
            pack = Instantiate(healPackPrefab);
            pack.transform.position = spawnPosition;
        }
        if (powerUp == "shield")
        {
            pack = Instantiate(shieldPackPrefab);
            pack.transform.position = spawnPosition;
        }
    }

   

    private void SpawnPos()
    {
        float cordX = Random.Range(screenBorders.x * -1 + spriteWidth * 2, screenBorders.x - spriteWidth * 2);
        float cordY = screenBorders.y * -1 - spriteHeight * 2;
        spawnPosition = new Vector2(cordX, cordY);
    }


    private void ChosePowerUp()
    {
        int r = Random.Range(0, 2);
        if (r == 0) powerUp = "heal";
        if (r == 1) powerUp = "shield";
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
