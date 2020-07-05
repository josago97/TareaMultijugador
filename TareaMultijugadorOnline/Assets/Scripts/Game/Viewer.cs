using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewer : MonoBehaviour
{
    [SerializeField] private Transform[] points;

    private int _position;

    public void View()
    {
        Camera.main.transform.SetParent(transform, false);
    }
}
