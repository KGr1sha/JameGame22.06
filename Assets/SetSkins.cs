using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSkins : MonoBehaviour
{
    public void SetPlayerSkin(string skin)
    {
        PlayerPrefs.SetString("skin", skin);
    }
}
