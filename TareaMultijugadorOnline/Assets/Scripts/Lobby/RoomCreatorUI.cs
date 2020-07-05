using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class RoomCreatorUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameIPF;
    [SerializeField] private Button createtBTN;

    private LobbyManagerNet _lobbyManagerNet;
    private GameSettings _gameSettings;

    [Inject]
    private void Construct(LobbyManagerNet lobbyManagerNet, GameSettings gameSettings)
    {
        _lobbyManagerNet = lobbyManagerNet;
        _gameSettings = gameSettings;
    }

    private void Awake()
    {
        nameIPF.onValueChanged.AddListener(CheckRoomName);
        CheckRoomName(nameIPF.text);
    }

    public void CreateRoom()
    {
        string roomName = nameIPF.text.Trim();
        if (!string.IsNullOrEmpty(roomName))
        {
            _lobbyManagerNet.CreateRoom(roomName, _gameSettings.MaxPlayerCount);
        }
    }

    private void CheckRoomName(string roomName)
    {
        roomName = roomName.Trim();
        int size = roomName.Length;

        bool isEmpty = size == 0;

        createtBTN.interactable = !isEmpty;
    }
}
