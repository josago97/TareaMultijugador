using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Zenject;

public class SettingPlayer : MonoBehaviour
{
    [SerializeField] private Color errorColor;
    [SerializeField] private TMP_InputField nicknameIPF;
    [SerializeField] private TextMeshProUGUI nicknameRulesTXT;
    [SerializeField] private Button accceptBTN;

    [Inject] private PlayerSettings _playerSettings;

    private Color _defaultColor;
    private int _maxSizeNickName;

    private void Start()
    {
        InitNickName();
    }

    private void InitNickName()
    {
        _maxSizeNickName = _playerSettings.MaxSizeNickname;
        _defaultColor = nicknameIPF.textComponent.color;
        nicknameIPF.onValueChanged.AddListener(CheckNickName);
        nicknameRulesTXT.text = $"Máximo {_maxSizeNickName} caracteres";
        CheckNickName(nicknameIPF.text);
    }

    private void CheckNickName(string nickname)
    {
        int size = nickname.Trim().Length;

        bool isEmpty = size == 0;
        bool isOverMax = size > _maxSizeNickName;

        accceptBTN.interactable = !isEmpty && !isOverMax;
        nicknameIPF.textComponent.color = isOverMax ? errorColor : _defaultColor;
    }

}
