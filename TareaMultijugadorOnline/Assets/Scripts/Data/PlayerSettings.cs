using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/Player")]
public class PlayerSettings : ScriptableObject
{
    [SerializeField] private int maxSizeNickname;

    public int MaxSizeNickname => maxSizeNickname;
}
