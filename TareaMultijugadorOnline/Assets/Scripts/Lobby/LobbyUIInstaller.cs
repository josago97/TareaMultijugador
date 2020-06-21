using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LobbyUIInstaller : MonoInstaller
{
    [SerializeField] private LobbyMenuUI lobbyMenu;
    [SerializeField] private LoadMessageUI loadMessage;
    [SerializeField] private PlayerSettingsUI playerSettings;
    [SerializeField] private RoomListUI roomList;
    [SerializeField] private RoomCreatorUI roomCreator;

    public override void InstallBindings()
    {
        Container.BindInstances(
            lobbyMenu,
            loadMessage,
            playerSettings,
            roomList,
            roomCreator);
    }
}
