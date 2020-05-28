using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadMessage : MonoBehaviour
{
    [SerializeField] private string message;
    [SerializeField] private float time;
    [SerializeField] private TextMeshProUGUI messageTXT;

    private void OnEnable()
    {
        StartCoroutine(LoadCor());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator LoadCor()
    {
        int maxCount = 4;
        int count = Random.Range(0, maxCount);

        while (true)
        {
            messageTXT.text = $"{message}{new string('.', count)}";
            yield return new WaitForSeconds(time);
            count = (count + 1) % (maxCount + 1);
        }
    }
}
