using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class RoomListUI : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform container;

    private LobbyManagerNet _lobbyManagerNet;
    private List<RoomSlot> _rooms;

    [Inject]
    private void Construct(LobbyManagerNet lobbyManagerNet)
    {
        _lobbyManagerNet = lobbyManagerNet;

        _rooms = new List<RoomSlot>();
    }

    private void Awake()
    {
        Clear();
    }

    public void UpdateList(List<RoomInfo> roomList)
    {
        foreach (var room in roomList)
        {
            if (room.RemovedFromList)
            {
                RemoveRoom(room);
            }
            else
            {
                AddRoom(room);
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

    private void RemoveRoom(RoomInfo roomInfo)
    {
        var slot = _rooms.Find(s => s.Name == roomInfo.Name);

        if(slot != null)
        {
            _rooms.Remove(slot);
            Destroy(slot.gameObject);
        }
    }

    private void AddRoom(RoomInfo roomInfo)
    {
        if (_rooms.Find(s => s.Name == roomInfo.Name) == null)
        {
            RoomSlot slot = Instantiate(slotPrefab, container).GetComponent<RoomSlot>();
            slot.Name = roomInfo.Name;
            if (roomInfo.IsOpen)
            {
                slot.JoinButton.onClick.AddListener(() => _lobbyManagerNet.JoinRoom(roomInfo.Name));
            }
            else
            {
                slot.JoinButton.interactable = false;
            }

            _rooms.Add(slot);
        }
    }
}
