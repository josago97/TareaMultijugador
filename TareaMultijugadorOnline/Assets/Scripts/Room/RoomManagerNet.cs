using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RoomManagerNet : MonoBehaviour
{
    private SceneLoader _sceneLoader;
    private NetManager _netManager;

    [Inject]
    private void Construct(SceneLoader sceneLoader, NetManager netManager)
    {
        _sceneLoader = sceneLoader;
        _netManager = netManager;
    }

    public void Play()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        _sceneLoader.LoadGame();
    }

    public void Back()
    {
        if (PhotonNetwork.InRoom)
        {
            _netManager.LeftRoom += GoLobby;
            PhotonNetwork.LeaveRoom();
        }
        else
            GoLobby();
    }

    public void GoLobby()
    {
        _netManager.LeftRoom -= GoLobby;
        _sceneLoader.LoadLobby();
    }
}
