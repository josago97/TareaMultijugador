using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/Game")]
public class GameSettings : ScriptableObject
{
    [SerializeField] private int maxPlayerCount;
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color[] colors;

    public int MaxPlayerCount => maxPlayerCount;
    public Color Default => defaultColor;
    public Color[] Colors => colors;
}
