using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ColorSelector : MonoBehaviour
{
    private List<int> _colors;

    private NetManager _netManager;
    private GameSettings _gameSettings;

    [Inject]
    private void Construct(NetManager netManager, GameSettings gameSettings)
    {
        _netManager = netManager;
        _gameSettings = gameSettings;

        _colors = new List<int>();
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
        _netManager.PlayerJoined -= OnPlayerJoined;
        _netManager.PlayerLeft -= OnPlayerLeft;
    }

    private void OnMasterClientChanged(Player newMasterClient)
    {
        if (newMasterClient != null && newMasterClient.IsLocal)
        {
            UpdateColors();

            _netManager.PlayerJoined += OnPlayerJoined;
            _netManager.PlayerLeft += OnPlayerLeft;
        }
    }

    private void UpdateColors()
    {
        foreach(var player in _netManager.PlayersInCurrentRoom)
        {
            OnPlayerJoined(player);
        }
    }

    private void OnPlayerJoined(Player player)
    {
        int color;

        if(!player.TryGetColor(out color))
        {
            color = FindColor();
            player.SetColor(color);
        }

        _colors.Add(color);
    }

    private void OnPlayerLeft(Player player)
    {
        player.TryGetColor(out int color);
        _colors.Remove(color);
    }

    private int FindColor()
    {
        int color = -1;
        int numColors = _gameSettings.Colors.Length;
        int aux = Random.Range(0, numColors);

        for (int i = 0; i < numColors; i++)
        {
            if (!_colors.Contains(aux))
            {
                color = aux;
                break;
            }

            aux++;
            if (aux >= numColors) aux = 0;
        }

        return color;
    }
}
