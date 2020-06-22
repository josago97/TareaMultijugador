using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/Scene")]
public class SceneSettings : ScriptableObject
{
    [SerializeField] private string lobby;
    [SerializeField] private string room;
    [SerializeField] private string game;

    public string Lobby => lobby;
    public string Room => room;
    public string Game => game;
}
