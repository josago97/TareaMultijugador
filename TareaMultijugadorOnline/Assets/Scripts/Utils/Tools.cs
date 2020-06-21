#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Tools : EditorWindow
{
    [MenuItem("Tools/Vaguesa/ChangeFont")]
    static void ChangeFontAllText()
    {
        var font = Selection.activeObject as TMP_FontAsset;
        var texts = FindObjectsOfType<TextMeshProUGUI>();
        Debug.Log(texts.Length);

        Array.ForEach(texts, t => t.font = font);
    }

    [MenuItem("Tools/Vaguesa/ChangeFont", true)]
    static bool ValidateChangeFontAllText()
    {
        return Selection.activeObject as TMP_FontAsset != null;
    }
}

#endif