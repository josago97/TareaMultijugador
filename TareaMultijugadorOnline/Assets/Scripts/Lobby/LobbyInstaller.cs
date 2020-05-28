using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LobbyInstaller : MonoInstaller
{
    [SerializeField] private LobbyManager lobbyManager;
    [SerializeField] private LobbyManagerNet lobbyManagerNet;

    public override void InstallBindings()
    {
        Container.BindInstance<ILobbyManagerNet>(lobbyManagerNet);
        Container.BindInstance(lobbyManager);
    }
}
