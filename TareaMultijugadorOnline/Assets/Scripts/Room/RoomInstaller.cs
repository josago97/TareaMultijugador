using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RoomInstaller : MonoInstaller
{
    [SerializeField] private RoomManagerNet roomManagerNet;

    public override void InstallBindings()
    {
        Container.BindInstances(roomManagerNet);
    }
}
