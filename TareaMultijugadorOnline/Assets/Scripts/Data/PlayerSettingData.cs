using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettingData
{
    private const string FILE_NAME = "player.dat";

    private string _nickname;

    public string Nickname
    {
        get => _nickname;
        set => ChangeValue(ref _nickname, value);
    }

    public PlayerSettingData()
    {
        Load();
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
