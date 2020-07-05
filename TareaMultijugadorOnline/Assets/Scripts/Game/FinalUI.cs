using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI winnerTXT;

    public void Show(string winner)
    {
        if (winner != null)
            winnerTXT.text = $"Ha ganado {winner}";
        else
            winnerTXT.text = "Empate";

        gameObject.SetActive(true);
        Debug.Log(winner);
    }
}
