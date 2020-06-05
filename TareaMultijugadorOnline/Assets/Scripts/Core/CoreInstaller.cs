﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CoreInstaller : MonoInstaller
{
    [SerializeField] private SceneLoader sceneLoader;

    public override void InstallBindings()
    {
        Container.BindInstances(sceneLoader);
    }
}
