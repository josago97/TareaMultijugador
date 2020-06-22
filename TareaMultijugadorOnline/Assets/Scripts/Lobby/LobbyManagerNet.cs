using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LobbyManagerNet : MonoBehaviourPunCallbacks
{
    private LobbyMenuUI _lobbyMenu;
    private LoadMessageUI _loadMessage;
    private RoomListUI _roomList;
    private SceneLoader _sceneLoader;
    private PlayerData _playerData;

    [Inject]
    private void Construct(LobbyMenuUI lobbyMenu, LoadMessageUI loadMessage, RoomListUI roomList, 
                           SceneLoader sceneLoader, PlayerData playerData)
    {
        _loadMessage = loadMessage;
        _lobbyMenu = lobbyMenu;
        _roomList = roomList;
        _sceneLoader = sceneLoader;
        _playerData = playerData;
    }

    private void Start()
    {
        Connect();
    }

    public void CreateRoom(string name, int maxPlayerAmount)
    {
        RoomOptions options = new RoomOptions();
        options.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable();

        options.MaxPlayers = (byte)maxPlayerAmount;
        options.IsOpen = true;
        options.IsVisible = true;

        PhotonNetwork.CreateRoom(name, options, TypedLobby.Default);
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
        _loadMessage.Message = "Uniendo";
        _loadMessage.Show();
        _lobbyMenu.Hide();
    }


    private void Connect()
    {
        if (!PhotonNetwork.IsConnected)
        {
            SetNickname();
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();

            _loadMessage.Message = "Conectando";
            _loadMessage.Show();
            _lobbyMenu.Hide();
        }
        else
        {
            OnJoinedLobby();
        }
    }

    public void SetNickname()
    {
        PhotonNetwork.NickName = _playerData.Nickname;
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        _roomList.UpdateList(roomList);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        _loadMessage.Hide();
        _lobbyMenu.Show();
    }

    public override void OnJoinedRoom()
    {
        _sceneLoader.LoadRoom();
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        _loadMessage.Hide();
        _lobbyMenu.Show();
    }
}
