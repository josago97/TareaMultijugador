using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomSlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameTXT;
    [SerializeField] private Button joinBTN;


    public string Name
    {
        get => nameTXT.text;
        set => nameTXT.text = value;
    }

    public Button JoinButton => joinBTN;
}
