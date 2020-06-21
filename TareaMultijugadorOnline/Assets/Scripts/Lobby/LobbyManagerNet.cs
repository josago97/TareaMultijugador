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


    [Inject]
    private void Construct(LobbyMenuUI lobbyMenu, LoadMessageUI loadMessage, RoomListUI roomList)
    {
        _loadMessage = loadMessage;
        _lobbyMenu = lobbyMenu;
        _roomList = roomList;
    }

    private void Start()
    {
        Connect();
    }

    public bool CreateRoom(string name, int maxPlayerAmount)
    {
        RoomOptions options = new RoomOptions();
        options.CustomRoomProperties = new ExitGames.Client.Photon.Hashtable();

        options.MaxPlayers = (byte)maxPlayerAmount;
        options.IsOpen = true;
        options.IsVisible = true;

        /*options.CustomRoomProperties.SetValor(DatosSala.PUBLICO, publica);
        options.CustomRoomProperties.SetValor(DatosSala.ENJUEGO, false);
        options.CustomRoomProperties.SetValor(DatosSala.CONTRASENA, contrasena);

        options.CustomRoomPropertiesForLobby = new string[] { DatosSala.PUBLICO, DatosSala.CONTRASENA, DatosSala.ENJUEGO };*/

        //ManagerLobby.Instance.Uniendo(true);

        return PhotonNetwork.CreateRoom(name, options, TypedLobby.Default);
    }

    public void JoinRoom(string roomName)
    {

    }


    private void Connect()
    {
        if (!PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();

            _loadMessage.Message = "Conectando";
            _loadMessage.Show();
            _lobbyMenu.Hide();
        }
        else
        {
            OnConnected();
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        _roomList.UpdateList(roomList);
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Lobby");
    }

    public override void OnConnected()
    {
        Debug.Log("Connected");
        _loadMessage.Hide();
        _lobbyMenu.Show();
    }
}
