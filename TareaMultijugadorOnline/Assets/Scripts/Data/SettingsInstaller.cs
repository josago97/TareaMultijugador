using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Settings/Installer")]
public class SettingsInstaller : ScriptableObjectInstaller
{
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private SceneSettings sceneSettings;

    public override void InstallBindings()
    {
        Container.BindInstances(gameSettings, playerSettings, sceneSettings);
    }
}
