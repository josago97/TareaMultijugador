using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static PlayerControls;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float linearSpeed;
    [SerializeField] private float angularSpeed;
    [SerializeField] private float cameraAngularSpeed;
    [SerializeField] private Transform cameraPosition;
    [SerializeField] private Vector2 cameraRotation;

    private PlayerControls _controls;
    private Vector3 _moveDirection;
    private Vector2 _turnDirection;
    private Rigidbody _rigid;
    private float _cameraRotation;

    private class Input : IGameActions
    {
        private PlayerController _controller;

        public Input(PlayerController controller)
        {
            _controller = controller;
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            var dir = context.ReadValue<Vector2>();
            _controller._moveDirection = new Vector3(dir.x, 0, dir.y);
            _controller._moveDirection.Normalize();
        }

        public void OnTurn(InputAction.CallbackContext context)
        {
            var dir = context.ReadValue<Vector2>();
            _controller._turnDirection = dir;
            //Debug.Log(dir);
        }
    }

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
        _controls = new PlayerControls();
        _controls.Game.SetCallbacks(new Input(this));
        Activate();
    }

    private void FixedUpdate()
    {
        Rotate();
        Move();
    }

    private void LateUpdate()
    {
        RotateCamera();
    }

    public void Activate()
    {
        _controls.Enable();
    }

    public void Deactivate()
    {
        _controls.Disable();
    }

    private void Move()
    {
        var velocity = _rigid.velocity;
        var newVelocity = transform.TransformDirection(_moveDirection * linearSpeed);
        newVelocity.y = velocity.y;
        _rigid.velocity = newVelocity;
    }

    private void Rotate()
    {
        var rotation = Quaternion.Euler(0, _turnDirection.x * angularSpeed * Time.fixedDeltaTime, 0);
        _rigid.MoveRotation(_rigid.rotation * rotation);
    }

    private void RotateCamera()
    {
        _cameraRotation = _cameraRotation - _turnDirection.y * cameraAngularSpeed * Time.fixedDeltaTime;
        _cameraRotation = Mathf.Clamp(_cameraRotation, cameraRotation.x, cameraRotation.y);
        cameraPosition.localEulerAngles = new Vector3(_cameraRotation, 0, 0);
    }
}
