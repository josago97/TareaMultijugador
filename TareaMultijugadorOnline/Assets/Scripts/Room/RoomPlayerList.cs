using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RoomPlayerList : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform container;

    private NetManager _netManager;

    [Inject]
    private void Construct(NetManager netManager)
    {
        _netManager = netManager;
    }

    private void Start()
    {
        UpdateList();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void UpdateList()
    {
        Clear();

        foreach (var player in PhotonNetwork.PlayerList)
        {
            var playerStyle = Instantiate(playerPrefab, container).GetComponent<PlayerStyle>();
            playerStyle.Name = player.NickName;
        }
    }

    private void Clear()
    {
        for (int i = container.childCount - 1; i >= 0; i--)
        {
            Destroy(container.GetChild(i).gameObject);
        }
    }
}
