using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RoomMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject[] masterUI;
    [SerializeField] private GameObject[] clientUI;

    private RoomManagerNet _roomManagerNet;
    private NetManager _netManager;

    [Inject]
    private void Construct(RoomManagerNet roomManagerNet, NetManager netManager)
    {
        _roomManagerNet = roomManagerNet;
        _netManager = netManager;
    }

    private void Start()
    {
        OnMasterClientChanged(_netManager.MasterClient);
    }

    private void OnEnable()
    {
        _netManager.MasterClientChanged += OnMasterClientChanged;
    }

    private void OnDisable()
    {
        _netManager.MasterClientChanged -= OnMasterClientChanged;
    }

    public void Back()
    {
        _roomManagerNet.Back();
    }

    public void Play()
    {
        _roomManagerNet.Play();
    }

    private void OnMasterClientChanged(Player newMasterClient)
    {
        if (newMasterClient != null)
        {
            Array.ForEach(masterUI, g => g.SetActive(newMasterClient.IsLocal));
            Array.ForEach(clientUI, g => g.SetActive(!newMasterClient.IsLocal));
        }
    }
}
