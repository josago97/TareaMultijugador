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

    private bool isQuitting;

    [Inject]
    private void Construct(SceneSettings settings)
    {
        _settings = settings;

        isQuitting = false;
        Application.quitting += () => isQuitting = true;
    }

    public void LoadLobby()
    {
        Load(_settings.Lobby);
    }

    public void LoadRoom()
    {
        Load(_settings.Room);
    }

    public void LoadRoomPhoton()
    {
        LoadPhoton(_settings.Room);
    }

    public void LoadGamePhoton()
    {
        LoadPhoton(_settings.Game);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void Load(string sceneName)
    {
        if(!isQuitting)
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    private void LoadPhoton(string sceneName)
    {
        if (!isQuitting)
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.LoadLevel(sceneName);
        }
    }
}
