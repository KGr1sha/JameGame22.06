using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSkins : MonoBehaviour
{
    [SerializeField] GameObject bob;
    private SpriteRenderer bobSprite;

    [Header("SKINS")]
    [SerializeField] Sprite defaultSkin;
    [SerializeField] Sprite halal;
    [SerializeField] Sprite monkey;
    [SerializeField] Sprite money;
    [SerializeField] Sprite shit;
    [SerializeField] Sprite notabean;




    private void Awake()
    {
        string chosenSkin = GetSkin();
        switch (chosenSkin)
        {
            case "default":
                bobSprite.sprite = defaultSkin;
                break;
            case "halal":
                bobSprite.sprite = halal;
                break;
            case "monkey":
                bobSprite.sprite = monkey;
                break;
            case "money":
                bobSprite.sprite = money;
                break;
            case "shit":
                bobSprite.sprite = shit;
                break;
            case "notabean":
                bobSprite.sprite = notabean;
                break;
        }
    }



    public void SetPlayerSkin(string skin)
    {
        PlayerPrefs.SetString("skin", skin);
    }

    private string GetSkin()
    {
        return PlayerPrefs.GetString("skin");
    }


}
