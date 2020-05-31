using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/Game")]
public class GameSettings : ScriptableObject
{
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color[] colors;

    public Color Default => defaultColor;
    public Color[] Colors => colors;
}
