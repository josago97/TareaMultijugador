using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RoomPlayerList : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform container;

    private NetManager _netManager;
    private GameSettings _gameSettings;

    private Action<Player> _playerJoined;
    private Action<Player> _playerLeft;

    [Inject]
    private void Construct(NetManager netManager, GameSettings gameSettings)
    {
        _netManager = netManager;
        _gameSettings = gameSettings;

        _playerJoined = _ => UpdateList();
        _playerLeft = _ => UpdateList();
    }

    private void Start()
    {
        UpdateList();
    }

    private void OnEnable()
    {
        _netManager.PlayerJoined += _playerJoined;
        _netManager.PlayerLeft += _playerLeft;
        _netManager.PlayerPropertiesUpdated += UpdatePlayer;
    }

    private void OnDisable()
    {
        _netManager.PlayerJoined -= _playerJoined;
        _netManager.PlayerLeft -= _playerLeft;
        _netManager.PlayerPropertiesUpdated -= UpdatePlayer;
    }

    private void UpdateList()
    {
        Clear();

        foreach (var player in PhotonNetwork.PlayerList)
        {
            var playerStyle = Instantiate(playerPrefab, container).GetComponent<PlayerStyle>();
            player.TryGetColor(out int color);
            playerStyle.SetData(player.NickName, color);
        }
    }

    private void Clear()
    {
        for (int i = container.childCount - 1; i >= 0; i--)
        {
            Destroy(container.GetChild(i).gameObject);
        }
    }

    private void UpdatePlayer(Player player, ExitGames.Client.Photon.Hashtable props)
    {
        UpdateList();
    }
}
