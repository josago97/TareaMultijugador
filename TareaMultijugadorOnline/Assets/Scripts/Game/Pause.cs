using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerControls;

public class Pause : MonoBehaviour, IPauseActions
{
    [SerializeField] private PauseUI pauseUI;

    private PlayerControls _controls;
    private bool isPaused;

    private void Awake()
    {
        _controls = new PlayerControls();
        _controls.Pause.SetCallbacks(this);
        _controls.Enable();

        QuitPause();
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (isPaused)
                QuitPause();
            else
                SetPause();
        }
    }

    private void SetPause()
    {
        pauseUI.gameObject.SetActive(true);
        isPaused = true;
        Cursor.visible = true;
    }

    private void QuitPause()
    {
        pauseUI.gameObject.SetActive(false);
        isPaused = false;
        Cursor.visible = false;
    }

    private void OnDestroy()
    {
        Cursor.visible = true;
    }
}
