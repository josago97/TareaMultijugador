using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetManager : MonoBehaviourPunCallbacks
{
    public event Action ConnectedToMaster;
    public event Action LeftRoom;
    public event Action<Player> PlayerEntered;
    public event Action<Player> PlayerLeft;


    public override void OnConnectedToMaster()
    {
        ConnectedToMaster?.Invoke();
    }

    public override void OnLeftRoom()
    {
        LeftRoom?.Invoke();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        PlayerEntered?.Invoke(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        PlayerLeft?.Invoke(otherPlayer);
    }
}
