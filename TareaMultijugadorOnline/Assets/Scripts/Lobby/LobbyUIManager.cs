using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIManager : MonoBehaviour
{
    [SerializeField] private GameObject connecting;
    [SerializeField] private GameObject joinning;

    public void SetConnecting(bool isConnecting)
    {
        connecting.SetActive(isConnecting);
    }

    public void SetJoinning(bool isJoinning)
    {
        joinning.SetActive(isJoinning);
    }
}
