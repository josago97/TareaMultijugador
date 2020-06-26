using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class SceneLoader : MonoBehaviour
{
    public event Action LevelLoaded;

    private SceneSettings _settings;

    [Inject]
    private void Construct(SceneSettings settings)
    {
        _settings = settings;
    }

    private void Awake()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }

    public void LoadLobby()
    {
        Debug.Log("Load Lobby");
        Load(_settings.Lobby);
    }

    public void LoadRoom()
    {
        Load(_settings.Room);
    }

    public void LoadGame()
    {
        Load(_settings.Game);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void LoadScene(int buildIndex)
    {
        LoadScene(SceneManager.GetSceneByBuildIndex(buildIndex));
    }

    public void LoadScene(Scene scene)
    {
        Load(scene.name);
    }

    public void LoadScene(string sceneName)
    {
        Load(sceneName);
    }

    public void Reload()
    {
        LoadScene(SceneManager.GetActiveScene());
    }

    private void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    //TODO: Para la pantalla de carga
    private void LoadAsync()
    {

    }

    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LevelLoaded?.Invoke();
    }
}
