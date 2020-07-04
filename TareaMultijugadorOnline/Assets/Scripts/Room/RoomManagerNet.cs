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

    private void OnEnable()
    {
        _netManager.LeftRoom += GoLobby;
    }

    private void OnDisable()
    {
        _netManager.LeftRoom -= GoLobby;
    }

    public void Play()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        _sceneLoader.LoadGamePhoton();
    }

    public void Back()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
        }
        else
            GoLobby();
    }

    public void GoLobby()
    {
        _sceneLoader.LoadLobby();
    }
}
