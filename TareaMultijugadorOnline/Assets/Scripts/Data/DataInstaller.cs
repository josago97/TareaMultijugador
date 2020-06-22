using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class DataInstaller : MonoInstaller
{
    [SerializeField] private GameObject corePrefab;

    public override void InstallBindings()
    {
        //Container.Bind<SceneLoader>().FromComponentInNewPrefab(corePrefab).AsSingle().NonLazy();
        Container.Bind<PlayerData>().AsSingle().OnInstantiated<PlayerData>((c, p) => p.Load());
    }
}
