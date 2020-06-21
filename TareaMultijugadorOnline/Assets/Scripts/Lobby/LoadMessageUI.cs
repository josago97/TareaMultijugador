using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LoadMessageUI : UIBase
{
    [SerializeField] private string message;
    [SerializeField] private float time;
    [SerializeField] private TextMeshProUGUI messageTXT;

    public string Message
    {
        get => message;
        set => message = value;
    }

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
        string[] messages = Enumerable.Range(0, maxCount).Select(n => $"{message}{new string('.', n)}").ToArray();
        int index = Random.Range(0, messages.Length);

        while (true)
        {
            messageTXT.text = messages[index];
            yield return new WaitForSeconds(time);
            index = (index + 1) % messages.Length;
        }
    }
}
