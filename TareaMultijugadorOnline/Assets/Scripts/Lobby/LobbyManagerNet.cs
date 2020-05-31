using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LobbyManagerNet : MonoBehaviourPunCallbacks, ILobbyManagerNet
{
    [Inject] private LobbyManager _lobbyManager;
    //[Inject] private LobbyUIManager _lobbyUIManager;

    private void Start()
    {
        Connect();
    }

    private void Connect()
    {
        if (!PhotonNetwork.IsConnectedAndReady)
        {
            //ManagerLobby.Instance.Conectando(true);
            //PhotonNetwork.autojoinLobby = true;
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();
        }
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


    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        //listaSala.MostrarLista(roomList);
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Lobby");
    }

    public override void OnConnected()
    {
        Debug.Log("Connected");
        //_lobbyUIManager.SetConnectingUIActive(false);
    }
}
