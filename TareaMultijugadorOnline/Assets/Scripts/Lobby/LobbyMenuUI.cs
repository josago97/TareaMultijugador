using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LobbyMenuUI : UIBase
{
    private SceneLoader _sceneLoader;

    [Inject]
    private void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    public void Exit()
    {
        _sceneLoader.Exit();
    }
}
