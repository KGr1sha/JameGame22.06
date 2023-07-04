using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSkins : MonoBehaviour
{
    [SerializeField] GameObject bob;
    [SerializeField] PlayerData playerData;

    private void Awake()
    {
        bob.GetComponent<SpriteRenderer>().sprite = playerData.playerSkin;
    }
    public void SetPlayerSkin(Sprite skin)
    {
        playerData.playerSkin = skin;
    }
}
