using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    [SerializeField] private GameObject platform;
    [SerializeField] private Vector3 space;

    private void Awake()
    {
        HidePlatform();
    }

    public Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-space.x, space.x), 0, Random.Range(-space.z, space.z));
    }

    public void ShowPlatform(Vector3 position, float size)
    {
        platform.transform.position = position;
        platform.transform.localScale = new Vector3(size, 1, size);
        platform.SetActive(true);
    }

    public void HidePlatform()
    {
        platform.SetActive(false);
    }
}
