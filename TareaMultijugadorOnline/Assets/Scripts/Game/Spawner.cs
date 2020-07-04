using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform[] points;
    
    public GameObject Spawn(int id)
    {
        Transform point = points[id];
        var instance =  PhotonNetwork.Instantiate(playerPrefab.name, point.position, point.rotation);

        instance.GetComponent<PlayerController>().SetCamera(Camera.main);

        return instance;
    }
}
