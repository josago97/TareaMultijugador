using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Zenject;

public class PlayerSettingsUI : MonoBehaviour
{
    [SerializeField] private Color errorColor;
    [SerializeField] private TMP_InputField nicknameIPF;
    [SerializeField] private TextMeshProUGUI nicknameRulesTXT;
    [SerializeField] private Button accceptBTN;

    private PlayerSettings _playerSettings;
    private PlayerData _playerData;

    private Color _defaultColor;
    private int _maxSizeNickName;
    private string _nickname;

    [Inject]
    private void Construct(PlayerSettings playerSettings, PlayerData playerData)
    {
        _playerSettings = playerSettings;
        _playerData = playerData;
    }

    private void Start()
    {
        InitNickName();
    }

    public void Save()
    {
        string newNickName = nicknameIPF.text.Trim();
        _playerData.Nickname = newNickName;
        _nickname = _playerData.Nickname;
        CheckNickName(nicknameIPF.text);
    }

    private void InitNickName()
    {
        _nickname = _playerData.Nickname;
        _maxSizeNickName = _playerSettings.MaxSizeNickname;
        _defaultColor = nicknameIPF.textComponent.color;
        nicknameIPF.text = _nickname;
        nicknameIPF.onValueChanged.AddListener(CheckNickName);
        nicknameRulesTXT.text = $"Máximo {_maxSizeNickName} caracteres";
        CheckNickName(nicknameIPF.text);
    }

    private void CheckNickName(string nickname)
    {
        string newNickName = nickname.Trim();
        int size = newNickName.Length;

        bool isEmpty = size == 0;
        bool isOverMax = size > _maxSizeNickName;
        bool isEqual = _nickname == newNickName;

        accceptBTN.interactable = !isEmpty && !isOverMax && !isEqual;
        nicknameIPF.textComponent.color = isOverMax ? errorColor : _defaultColor;
    }
}
