using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyUIManager : MonoBehaviour
{
    [SerializeField] private GameObject connecting;
    [SerializeField] private GameObject joinning;

    private void Start()
    {
        //SetJoinningUIActive(false);
    }

    public void SetConnectingUIActive(bool isConnecting)
    {
        connecting.SetActive(isConnecting);
    }

    public void SetJoinningUIActive(bool isJoinning)
    {
        joinning.SetActive(isJoinning);
    }
}
