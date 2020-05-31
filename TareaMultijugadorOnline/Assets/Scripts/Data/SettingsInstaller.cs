using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Settings/Installer")]
public class SettingsInstaller : ScriptableObjectInstaller
{
    public GameSettings gameSettings;
    public PlayerSettings playerSettings;

    public override void InstallBindings()
    {
        Container.BindInstances(gameSettings, playerSettings);
    }
}
