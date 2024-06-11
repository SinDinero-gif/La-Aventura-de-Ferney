using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SpriteRenderer _spriteRenderer;


    private float _moveSpeed = 4f;
    private float _jumpForce = 6f;
    private Vector3 movement;
    private float _hInput;
    private float _vInput;

    private bool _isGrounded;

    private Rigidbody _rb;
    private PlayerInput _playerInput;
    private PlayerInputs _playerInputActions;

    private Vector2 _inputVector;




    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();

        _playerInputActions = new PlayerInputs();
        _playerInputActions.Player.Enable();
        _playerInputActions.Player.Move.performed += Move_performed;
        
    }

    private void Start()
    {
        
    }

    private void Move_performed(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        _inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();
        _rb.velocity = new Vector3(_inputVector.x, 0, _inputVector.y) * _moveSpeed;

    }

    void Update()
    {
        Move();
        


        FLip();

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            StartCoroutine(Jump());
        }

        
    }

    private void Move()
    {
        _inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();
        _rb.velocity = new Vector3(_inputVector.x, 0, _inputVector.y) * _moveSpeed;

        if(_inputVector.x > 0 || _inputVector.x < 0)
        {
            _player.playerAnimator.SetBool("Walking", true);
        }
        else
        {
            _player.playerAnimator.SetBool("Walking", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
            _player.playerAnimator.SetBool("Grounded", true);
        }
    }

    private IEnumerator Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _isGrounded = false;
        _player.playerAnimator.SetBool("Jump", true);
        _player.playerAnimator.SetBool("Grounded", false);

        yield return new WaitForSeconds(0.3f);

        _player.playerAnimator.SetBool("Jump", false);
        _player.playerAnimator.SetBool("Grounded", false);
    }

    private void FLip()
    {
        if (_inputVector.x < 0)
        {
           _spriteRenderer.flipX = true;
            

        }
        else if (_inputVector.x > 0)
        {
            _spriteRenderer.flipX = false;
            
        }
    }
}
