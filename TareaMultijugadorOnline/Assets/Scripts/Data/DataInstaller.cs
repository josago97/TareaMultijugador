using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DataInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var playerData = new PlayerData();
        playerData.Load();
        Container.BindInstance(playerData);
    }
}
