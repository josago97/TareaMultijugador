using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStyle : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameTXT;
    [SerializeField] private MeshRenderer meshRenderer;

    public string Name
    {
        set => nameTXT.text = value;
    }

    public Color Color
    {
        set => meshRenderer.material.color = value;
    }
}
