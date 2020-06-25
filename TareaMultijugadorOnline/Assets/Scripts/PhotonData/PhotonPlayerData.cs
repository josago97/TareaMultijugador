using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PhotonPlayerData
{
    private const string colorKey = "c";

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

    private static void SetData(Player player, string key, object data)
    {
        ExitGames.Client.Photon.Hashtable datos = player.CustomProperties ?? new ExitGames.Client.Photon.Hashtable();
        datos.Add(key, data);
        player.SetCustomProperties(datos);
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
