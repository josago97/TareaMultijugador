using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Spawner spawner;

    public override void InstallBindings()
    {
        Container.BindInstances(gameManager, spawner);
    }
}
