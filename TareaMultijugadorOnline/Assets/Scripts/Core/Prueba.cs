using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Prueba : MonoBehaviour
{
    [Inject] SceneLoader sceneLoader;

    private void Awake()
    {
        Debug.Log(sceneLoader);
    }
}
