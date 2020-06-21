using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    private const string FILE_NAME = "player.dat";

    [JsonProperty]
    [SerializeField]
    private string _nickname;

    [JsonIgnore]
    public string Nickname
    {
        get => _nickname;
        set => ChangeValue(ref _nickname, value);
    }

    public void Save()
    {
        FileSystem.SaveEncrypt(this, FILE_NAME);
    }

    public void Load()
    {
        if (FileSystem.LoadEncrypt(FILE_NAME, out string data))
        {
            JsonUtility.FromJsonOverwrite(data, this);
        }
    }

    private void ChangeValue<T>(ref T variable, T value)
    {
        variable = value;
        Save();
    }
}
