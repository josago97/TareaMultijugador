using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class RoomCreatorUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameIPF;

    private LobbyManagerNet _lobbyManagerNet;
    private GameSettings _gameSettings;

    [Inject]
    private void Construct(LobbyManagerNet lobbyManagerNet, GameSettings gameSettings)
    {
        _lobbyManagerNet = lobbyManagerNet;
        _gameSettings = gameSettings;
    }

    public void CreateRoom()
    {
        string roomName = nameIPF.text.Trim();
        if (!string.IsNullOrEmpty(roomName))
        {
            _lobbyManagerNet.CreateRoom(roomName, _gameSettings.MaxPlayerCount);
        }
    }
}
