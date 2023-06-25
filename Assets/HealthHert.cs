using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHert : MonoBehaviour
{
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;
    Image heartImage;


    private void Awake()
    {
        heartImage = GetComponent<Image>();
    }


    public void SetHeartImage(string heartStatus)
    {
        if (heartStatus == "empty") heartImage.sprite = emptyHeart;
        if (heartStatus == "full") heartImage.sprite = fullHeart;
    }


}
