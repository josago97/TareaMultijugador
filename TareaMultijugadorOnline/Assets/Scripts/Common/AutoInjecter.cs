using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AutoInjecter : MonoBehaviour
{
    private void Awake()
    {
        var context = GetComponentInParent<RunnableContext>() ?? FindObjectOfType<SceneContext>();
        context.Container.InjectGameObject(gameObject);
    }
}
