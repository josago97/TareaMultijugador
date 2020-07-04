using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    enum GameState { WaitingPlayers, Playing }

    private GameState _gameState;
    private List<PlayerInfo> _players;
    private PhotonView _photonView;

    private Spawner _spawner;
    private NetManager _netManager;
    
    [Inject]
    private void Construct(Spawner spawner, NetManager netManager)
    {
        _spawner = spawner;
        _netManager = netManager;
    }

    private void Awake()
    {
        _photonView = PhotonView.Get(gameObject);
    }

    private void Start()
    {
        GetPlayers();
        _gameState = GameState.WaitingPlayers;
        _spawner.Spawn(_netManager.LocalPlayer.ActorNumber);
    }

    private void GetPlayers()
    {
        _players = new List<PlayerInfo>();

        foreach (var photonPlayer in _netManager.CurrentRoom.Players.Values)
        {
            var player = new PlayerInfo()
            {
                Id = photonPlayer.ActorNumber
            };

            _players.Add(player);
        }
    }



   /* IEnumerator GameplayCor()
    {
        yield return WaitingPlayersCor();

        _spawner
    }

    IEnumerator WaitingPlayersCor()
    {
        _photonView.RPC("Preparado", RpcTarget.All, PhotonNetwork.LocalPlayer.ActorNumber, fase);
        yield return new WaitUntil(() => jugadores.All(j => j.fase == fase));
    }*/
}
