using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InitialManager : MonoBehaviour
{
    private SceneLoader _sceneLoader;
    private PlayerData _playerData;

    [Inject]
    private void Construct(SceneLoader sceneLoader, PlayerData playerData, SceneSettings scene)
    {
        //Debug.Log(scene);
        _sceneLoader = sceneLoader;
        _playerData = playerData;
    }

    private void Start()
    {
        Debug.Log(_playerData.Nickname);
        if (!string.IsNullOrEmpty(_playerData.Nickname))
            GoLobby();
    }

    public void GoLobby()
    {
        _sceneLoader.LoadLobby();
    }

    public void Exit()
    {
        _sceneLoader.Exit();
    }
}
