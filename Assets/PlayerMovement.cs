using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _movement;
    private Rigidbody2D _rb;
    private float _speed = 5f;
    private float _acceleration = 30f;
    private float _deceleration = 15f;
    private float _turnAcceleration = 60f;

    private void Awake()
    {
        _rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    private void FixedUpdate()
    {
        float currentAcceleration;
        if(_movement.sqrMagnitude == 0)
        {
            currentAcceleration =  _deceleration;
        }
        else
        {
            currentAcceleration = _acceleration;
        }

        if (Vector2.Dot(_rb.linearVelocity, _movement) < 0)
        {
            currentAcceleration = _turnAcceleration;
        }
        _rb.linearVelocity = Vector2.MoveTowards(_rb.linearVelocity, _movement.normalized * _speed, currentAcceleration * Time.fixedDeltaTime );
    }
}
