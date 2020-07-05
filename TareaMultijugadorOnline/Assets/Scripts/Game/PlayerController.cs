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

    private void Update()
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

    public void SetCamera(Camera camera)
    {
        camera.transform.SetParent(cameraPosition, false);
        camera.transform.localPosition = Vector3.zero;
        camera.transform.localEulerAngles = Vector3.zero;
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
        float aux = 0;
        var rotation = transform.localEulerAngles.y + _turnDirection.x * angularSpeed * Time.fixedDeltaTime;
        rotation = Mathf.SmoothDampAngle(transform.localEulerAngles.y, rotation, ref aux, Time.fixedDeltaTime);
        _rigid.MoveRotation(Quaternion.Euler(0, rotation, 0));
    }

    private void RotateCamera()
    {
        float aux = 0;
        var rotation = _cameraRotation - _turnDirection.y * cameraAngularSpeed * Time.fixedDeltaTime;
        rotation = Mathf.Clamp(rotation, cameraRotation.x, cameraRotation.y);
        _cameraRotation = Mathf.SmoothDampAngle(_cameraRotation, rotation, ref aux, Time.fixedDeltaTime);
        cameraPosition.localEulerAngles = new Vector3(_cameraRotation, 0, 0);
    }
}
