using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class PlayerStyle : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameTXT;
    [SerializeField] private MeshRenderer meshRenderer;

    private GameSettings _gameSettings;

    [Inject]
    private void Construct (GameSettings gameSettings)
    {
        _gameSettings = gameSettings;
    }

    public void SetData(string name, int color)
    {
        nameTXT.text = name;

        if (color >= 0 && color < _gameSettings.Colors.Length)
        {
            meshRenderer.material.color = _gameSettings.Colors[color];
        }
        else
        {
            meshRenderer.material.color = _gameSettings.DefaultColor;
        }
    }
}
