using System;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    [Range(1.0f, 10.0f)]
    public float Speed = 5.0f;

    [SerializeField] private KeyCode _rightDirection;
    [SerializeField] private KeyCode _leftDirection;

    private float _direction;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _rb.linearVelocityX = _direction * Speed;
    }

    void Update()
    {
        _direction = 0.0f;

        if (Input.GetKey(_rightDirection))
            _direction += 1.0f;

        if (Input.GetKey(_leftDirection))
            _direction -= 1.0f;
    }
}

