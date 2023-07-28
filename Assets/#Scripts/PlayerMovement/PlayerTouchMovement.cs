using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

public class PlayerTouchMovement : MonoBehaviour
{
    [SerializeField] Vector2 _joystickSize;
    [SerializeField] FloatingJoystick _joystick;
    [SerializeField] NavMeshAgent _navMeshAgent;
    [SerializeField] Animator _animator;
    Finger _movementFinger;
    Vector2 _movementAmount;

    public bool _canMove = true;


    private void Update()
    {
        if (!_canMove) return;
        Vector3 scaledMovement = new Vector3(_movementAmount.x, 0, _movementAmount.y) * _navMeshAgent.speed * Time.deltaTime;
        _navMeshAgent.transform.LookAt(_navMeshAgent.transform.position + scaledMovement, Vector3.up);
        _navMeshAgent.Move(scaledMovement);
    }

    private void OnEnable()
    {
        ETouch.EnhancedTouchSupport.Enable();
        ETouch.Touch.onFingerDown += HandleFingerDown;
        ETouch.Touch.onFingerUp += HandleFingerUp;
        ETouch.Touch.onFingerMove += HandleFingerMove;
    }

    private void OnDisable()
    {
        ETouch.Touch.onFingerDown -= HandleFingerDown;
        ETouch.Touch.onFingerUp -= HandleFingerUp;
        ETouch.Touch.onFingerMove -= HandleFingerMove;
        ETouch.EnhancedTouchSupport.Disable();
    }

    private void HandleFingerMove(Finger finger)
    {
        if (!_canMove) return;
        if (_movementFinger != finger) return;
        Vector2 knobPosition;
        float maxMovement = _joystickSize.x / 2;
        ETouch.Touch currentTouch = finger.currentTouch;

        if(Vector2.Distance(currentTouch.screenPosition, _joystick._rectTransform.anchoredPosition) > maxMovement){
            knobPosition = (currentTouch.screenPosition - _joystick._rectTransform.anchoredPosition).normalized * maxMovement;
        }else{
            knobPosition = currentTouch.screenPosition - _joystick._rectTransform.anchoredPosition;
        }
        _joystick._knob.anchoredPosition = knobPosition;
        _movementAmount = knobPosition / maxMovement;
    }

    private void HandleFingerUp(Finger finger)
    {
        if (_movementFinger != finger) return;
        _movementFinger = null;
        _movementAmount = Vector2.zero;
        _joystick._knob.anchoredPosition = Vector2.zero;
        _joystick.gameObject.SetActive(false);
        _animator.SetBool("isRunning", false);
    }

    private void HandleFingerDown(Finger finger)
    {
        if (!_canMove) return;
        if (_movementFinger != null) return;
        _movementFinger = finger;
        _movementAmount = Vector2.zero;
        _joystick.gameObject.SetActive(true);
        _joystick._rectTransform.sizeDelta = _joystickSize;
        _joystick._rectTransform.anchoredPosition = ClampStartPosition(finger.screenPosition);
        _animator.SetBool("isRunning", true);
    }

    private Vector2 ClampStartPosition(Vector2 startPosition)
    {
        if(startPosition.x < _joystickSize.x / 2)
        {
            startPosition.x = _joystickSize.x / 2;
        }else if(startPosition.x > Screen.width - (_joystickSize.x / 2))
        {
            startPosition.x = Screen.width - (_joystickSize.x / 2);
        }

        if (startPosition.y < _joystickSize.y / 2)
        {
            startPosition.y = _joystickSize.y / 2;
        }
        else if (startPosition.y > Screen.height - (_joystickSize.y / 2))
        {
            startPosition.y = Screen.height - (_joystickSize.y / 2);
        }
        return startPosition;
    }
}
