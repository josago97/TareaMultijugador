using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RoomMenuUI : MonoBehaviour
{
    private RoomManagerNet _roomManagerNet;

    [Inject]
    private void Construct(RoomManagerNet roomManagerNet)
    {
        _roomManagerNet = roomManagerNet;
    }

    public void Back()
    {
        _roomManagerNet.Back();
    }

    public void Play()
    {
        _roomManagerNet.Play();
    }
}
