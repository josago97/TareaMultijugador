using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class PhotonPlayerData
{
    private const string colorKey = "c";

    public static void ClearCustomProperties(this Player player)
    {
        player.CustomProperties.Clear();
        player.SetCustomProperties(player.CustomProperties);
    }

    public static void SetColor(this Player player, int color)
    {
        SetData(player, colorKey, color);
    }

    public static bool TryGetColor(this Player player, out int color)
    {
        bool hasData = TryGetData(player, colorKey, out color);
        if (!hasData) color = -1;

        return hasData;
    }

    private static void SetData(Player player, string key, object value)
    {
        var data = new ExitGames.Client.Photon.Hashtable() { { key, value } };
        player.SetCustomProperties(data);
    }

    private static bool TryGetData<T>(Player player, string key, out T data)
    {
        data = default;
        bool hasData = false;

        if (player.CustomProperties.TryGetValue(key, out object aux))
        {
            data = (T)aux;
            hasData = true;
        }

        return hasData;
    }
}
