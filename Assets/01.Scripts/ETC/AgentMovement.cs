using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AgentMovement : MonoBehaviour
{
    [SerializeField] 
    private MovementDataSO _movementDataSO;

    private Rigidbody2D _rigidBody;

    protected float _currentVelocity = 0;
    protected Vector2 _movementDirection;

    public UnityEvent<float> OnVelocityChange;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void MoveAgent(Vector2 moveInput)
    {
        //키가 눌렸다
        if(moveInput.sqrMagnitude > 0)
        {
            //magnitude에 루트 x sqrMangnitude
            //반대 방향을 바라봤을 때
            if(Vector2.Dot(moveInput,_movementDirection) < 0)
            {
                _currentVelocity = 0;
            }
            _movementDirection = moveInput.normalized;
        }
        _currentVelocity = CalculateSpeed(moveInput);
    }

    private float CalculateSpeed(Vector2 moveInput)
    {
        if(moveInput.sqrMagnitude > 0)
        {
            _currentVelocity += _movementDataSO.acceleration * Time.deltaTime;

        }
        else
        {
            _currentVelocity -= _movementDataSO.deAcceleration * Time.deltaTime;

        }
        return Mathf.Clamp(_currentVelocity, 0, _movementDataSO.maxSpeed);
    }

    private void FixedUpdate()
    {
        OnVelocityChange?.Invoke(_currentVelocity);
        _rigidBody.velocity = _movementDirection * _currentVelocity;
    }
    public void StopImmediately()
    {
        _currentVelocity = 0;
        _rigidBody.velocity = Vector2.zero;
    }
}
