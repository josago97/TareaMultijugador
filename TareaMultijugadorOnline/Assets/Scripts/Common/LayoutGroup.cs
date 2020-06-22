using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LayoutGroup : MonoBehaviour
{
    [SerializeField] private float elementSize;
    [SerializeField] private float space;

    private void Update()
    {
        var elementsCount = transform.childCount;

        if (elementsCount > 0)
        {
            float totalSize = elementsCount * elementSize + (elementsCount - 1) * space;
            float step = elementSize + space;
            float start = -totalSize / 2 + elementSize / 2;

            for (int i = 0; i < elementsCount; i++)
            {
                var element = transform.GetChild(i);
                var newPostion = element.localPosition;
                newPostion.x = start + step * i;
                element.localPosition = newPostion;
            }

        }

    }
}
