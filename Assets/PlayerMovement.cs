using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _movement;
    private Rigidbody2D _rb;
    private float _speed = 5f;

    private void Awake()
    {
        _rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    private void FixedUpdate()
    {
        _rb.linearVelocity =  _movement.normalized * _speed;
    }
}

