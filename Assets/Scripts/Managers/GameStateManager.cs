using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    //Private
    private string _currentLocation;
    private List<string> locations = new List<string>()
    {
        "sky",
        "city",
        "cave1",
        "cave2",
        "core"
    };
    private void Start()
    {
        _currentLocation = locations[0];
    }

}
