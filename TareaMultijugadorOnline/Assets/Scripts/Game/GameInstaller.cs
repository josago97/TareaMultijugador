using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Spawner spawner;
    [SerializeField] private PlatformManager platformManager;
    [SerializeField] private Viewer viewer;

    public override void InstallBindings()
    {
        Container.BindInstances(gameManager, spawner, platformManager, viewer);
    }
}
