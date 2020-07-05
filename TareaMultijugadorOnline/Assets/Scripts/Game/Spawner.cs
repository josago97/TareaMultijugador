using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform[] points;

    private GameObject _instance;

    public GameObject Spawn(int id)
    {
        Transform point = points[id];
        _instance =  PhotonNetwork.Instantiate(playerPrefab.name, point.position, point.rotation);

        _instance.GetComponent<PlayerController>().SetCamera(Camera.main);

        return _instance;
    }

    private void OnDestroy()
    {
        PhotonNetwork.Destroy(_instance);
    }
}
