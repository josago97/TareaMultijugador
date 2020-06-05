using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SettingDataInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerSettingData>().AsSingle();
    }
}
