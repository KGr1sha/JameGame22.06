using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDraw : MonoBehaviour
{
    [SerializeField] GameObject heartPrefab;
    [SerializeField] BobLife bobHealth;
    List<HealthHert> hearts = new List<HealthHert>();

    private void Start()
    {
        DrawHearts();
    }


    public void DrawHearts()
    {
        ClearHearts();
        int heartsToMake = bobHealth.maxHealth;
        for(int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();
        }
    }



    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);
        HealthHert heartComponent = newHeart.GetComponent<HealthHert>();
        heartComponent.SetHeartImage("empty");
        hearts.Add(heartComponent);
    }
    public void ClearHearts()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthHert> ();
    }

}
