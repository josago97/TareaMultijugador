using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System;

public class NetManager : MonoBehaviourPunCallbacks
{
    public event Action ConnectedToMaster;
    public event Action LeftRoom;
    public event Action<Player> PlayerJoined;
    public event Action<Player> PlayerLeft;
    public event Action<Player> MasterClientChanged;
    public event Action<Player, Hashtable> PlayerPropertiesUpdated;

    public Player LocalPlayer => PhotonNetwork.LocalPlayer;
    public Player MasterClient => PhotonNetwork.MasterClient;
    public Room CurrentRoom => PhotonNetwork.CurrentRoom;
    public Player[] PlayersInCurrentRoom => PhotonNetwork.PlayerList;

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
        PlayerJoined?.Invoke(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        PlayerLeft?.Invoke(otherPlayer);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        MasterClientChanged?.Invoke(newMasterClient);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        PlayerPropertiesUpdated?.Invoke(targetPlayer, changedProps);
    }
}
