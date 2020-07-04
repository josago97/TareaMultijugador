using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneLoader : MonoBehaviour
{
    private SceneSettings _settings;

    [Inject]
    private void Construct(SceneSettings settings)
    {
        _settings = settings;
    }

    public void LoadLobby()
    {
        Load(_settings.Lobby);
    }

    public void LoadRoom()
    {
        Load(_settings.Room);
    }

    public void LoadGame()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.LoadLevel(_settings.Game);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void Load(string sceneName)
    {
        Debug.Log($"Load {sceneName}");
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
