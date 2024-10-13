using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private float _xInput;
    private float _zInput;

    private float _deadZone = 0.1f;

    private bool _isJump;
    private bool _isGround;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _xInput = Input.GetAxisRaw("Horizontal");
        _zInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
            _isJump = true;

    }

    private void FixedUpdate()
    {
        ProcessMove();

        ProcessJump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            _isGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            _isGround = false;
    }

    private void ProcessJump()
    {
        if (_isJump)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

            _isJump = false;
        }
    }

    private void ProcessMove()
    {
        if (Mathf.Abs(_zInput) > _deadZone)
        {
            _rigidbody.AddForce(Vector3.forward * _speed * _zInput, ForceMode.Force);
        }
        if (Mathf.Abs(_xInput) > _deadZone)
        {
            _rigidbody.AddForce(Vector3.right * _speed * _xInput, ForceMode.Force);
        }
    }
}
