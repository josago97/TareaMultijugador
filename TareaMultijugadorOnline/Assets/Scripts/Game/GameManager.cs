using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Vector2 musicTime;
    [SerializeField] private GameObject floor;

    private List<PlayerInfo> _players;
    private PhotonView _photonView;

    private Spawner _spawner;
    private NetManager _netManager;
    private SceneLoader _sceneLoader;
    private PlatformManager _platformManager;
    
    [Inject]
    private void Construct(Spawner spawner, NetManager netManager, SceneLoader sceneLoader, PlatformManager platformManager)
    {
        _spawner = spawner;
        _netManager = netManager;
        _sceneLoader = sceneLoader;
        _platformManager = platformManager;
    }

    private void Awake()
    {
        _photonView = PhotonView.Get(gameObject);
    }

    private void Start()
    {
        _spawner.Spawn(_netManager.LocalPlayer.ActorNumber);

        if (PhotonNetwork.MasterClient.IsLocal)
            StartCoroutine(GameplayCor());
    }

    private void OnEnable()
    {
        _netManager.LeftRoom += GoLobby;
        _netManager.MasterClientChanged += OnMasterClientChanged;
        _netManager.PlayerLeft += OnPlayerLeftRoom;
    }

    private void OnDisable()
    {
        _netManager.LeftRoom -= GoLobby;
        _netManager.MasterClientChanged -= OnMasterClientChanged;
        _netManager.PlayerLeft -= OnPlayerLeftRoom;
    }

    public void GoLobby()
    {
        _sceneLoader.LoadLobby();
    }

    private void GetPlayers()
    {
        _players = new List<PlayerInfo>();

        foreach (var networkPlayer in FindObjectsOfType<NetworkPlayer>())
        {
            var player = new PlayerInfo()
            {
                Id = networkPlayer.Id,
                IsAlive = true,
                GameObject = networkPlayer.gameObject
            };

            _players.Add(player);
        }
    }

    private void OnMasterClientChanged(Player newMasterClient)
    {
        PhotonNetwork.LeaveRoom();
    }

    private void OnPlayerLeftRoom(Player otherPlayer)
    {
        _players.RemoveAll(p => p.Id == otherPlayer.ActorNumber);
    }



    IEnumerator GameplayCor()
    {
        yield return WaitingPlayersCor();

        GetPlayers();

        float size = _players.Count * 1.75f;

        yield return new WaitForSeconds(3);

        while (_players.Where(p => p.IsAlive).Count() > 1)
        {         
            _photonView.RPC(nameof(PlayMusicRPC), RpcTarget.All, PhotonNetwork.Time);
            yield return new WaitForSeconds(Random.Range(musicTime.x, musicTime.y));
            _photonView.RPC(nameof(StopMusicRPC), RpcTarget.All, PhotonNetwork.Time, _platformManager.GetRandomPosition(), size);
            size *= 0.6f;
            yield return new WaitForSeconds(5);
            _photonView.RPC(nameof(HideFloorRPC), RpcTarget.All);
            yield return new WaitForSeconds(2);
            _photonView.RPC(nameof(HidePlatformRPC), RpcTarget.All);
        }
    }

    IEnumerator WaitingPlayersCor()
    {
        yield return new WaitUntil(() => FindObjectsOfType<NetworkPlayer>().Length == PhotonNetwork.PlayerList.Length);
    }

    [PunRPC]
    private void PlayMusicRPC(double time)
    {
        HidePlatformRPC();
        audioSource.time += (float)(PhotonNetwork.Time - time);
        audioSource.Play();
    }

    [PunRPC]
    private void StopMusicRPC(double time, Vector3 position, float size)
    {
        audioSource.Pause();
        audioSource.time -= (float)(PhotonNetwork.Time - time);
        _platformManager.ShowPlatform(position, size);
    }

    [PunRPC]
    private void HidePlatformRPC()
    {
        floor.gameObject.SetActive(true);
        _platformManager.HidePlatform();
    }

    [PunRPC]
    private void HideFloorRPC()
    {
        floor.gameObject.SetActive(false);
    }
}
