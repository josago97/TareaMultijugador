using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;
using static PlayerControls;

public class Pause : MonoBehaviour, IPauseActions
{
    [SerializeField] private PauseUI pauseUI;

    private GameManager _gameManager;

    private PlayerControls _controls;
    private bool isPaused;

    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

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
        _gameManager.LocalPlayer?.GetComponent<PlayerController>().Deactivate();
    }

    private void QuitPause()
    {
        pauseUI.gameObject.SetActive(false);
        isPaused = false;
        Cursor.visible = false;
        _gameManager.LocalPlayer?.GetComponent<PlayerController>().Activate();
    }

    private void OnDestroy()
    {
        Cursor.visible = true;
    }
}
