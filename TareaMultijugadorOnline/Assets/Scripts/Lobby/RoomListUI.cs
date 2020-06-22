using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RoomListUI : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform container;

    private LobbyManagerNet _lobbyManagerNet;

    [Inject]
    private void Construct(LobbyManagerNet lobbyManagerNet)
    {
        _lobbyManagerNet = lobbyManagerNet;
    }

    private void Start()
    {
        Clear();
    }

    public void UpdateList(List<RoomInfo> roomList)
    {
        Clear();

        foreach (var room in roomList)
        {
            if (room.IsVisible && !room.RemovedFromList)
            {
                RoomSlot slot = Instantiate(slotPrefab, container).GetComponent<RoomSlot>();
                slot.Name = room.Name;
                if (room.IsOpen)
                {
                    slot.JoinButton.onClick.AddListener(() => _lobbyManagerNet.JoinRoom(room.Name));
                }
                else
                {
                    slot.JoinButton.interactable = false;
                }
            }
        }
    }

    private void Clear()
    {
        for(int i = container.childCount - 1; i >= 0; i--)
        {
            Destroy(container.GetChild(i).gameObject);
        }
    }
}
