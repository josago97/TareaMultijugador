using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RoomManagerNet : MonoBehaviourPunCallbacks
{
    private SceneLoader _sceneLoader;

    [Inject]
    private void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    public void Play()
    {
        PhotonNetwork.CurrentRoom.IsOpen = false;
        _sceneLoader.LoadGame();
    }

    public void Back()
    {
        if (PhotonNetwork.InRoom)
            PhotonNetwork.LeaveRoom();
        else
            OnLeftRoom();
    }

    public override void OnLeftRoom()
    {
        _sceneLoader.LoadLobby();
    }
}
