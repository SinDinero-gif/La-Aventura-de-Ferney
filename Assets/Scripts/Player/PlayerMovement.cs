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
    [SerializeField] private Animator _animator;


    private float _moveSpeed = 4f;
    [SerializeField] private float _jumpForce = 20f;
    [SerializeField] private float _gForce = -9.8f;
    private Vector3 movement;
    private float _hInput;
    private float _vInput;

    [Header("Ground Check")]
    public Transform groundChekPos;
    public Vector2 groundCheckSize = new Vector2(0.1f, 0.1f);
    public LayerMask groundLayer;

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
        _playerInputActions.Player.Jump.performed += Jump;
        
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
    private void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded() && context.performed)
        {
            Debug.Log("Jump!");

            StartCoroutine(JumpMethod());
        }
       
    }

    private IEnumerator JumpMethod()
    {
        _rb.AddForce(Vector3.up * _jumpForce);


        yield return new WaitForSeconds(0.3f);



    }

    private bool isGrounded()
    {
        return Physics.Raycast(groundChekPos.position, Vector3.down, 0.6f, groundLayer);
    }
        

    void Update()
    {
        Move();

        Flip();

        isGrounded();
    }

    private void Move()
    {
        _inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();
        _rb.velocity = new Vector3(_inputVector.x, 0, _inputVector.y) * _moveSpeed;

        if(_inputVector.x != 0 && _inputVector.y != 0)
        {
            _animator.SetBool("Walking", true);
        }
        else
        {
            _animator.SetBool("Walking", false);
        }
    }

    private void FixedUpdate()
    {
        _rb.AddForce(new Vector3(_rb.velocity.x, _rb.velocity.y * -_gForce, _rb.velocity.z));
    }

    private void Flip()
    {
        if(_inputVector.x < 0)
        {
            _spriteRenderer.flipX = true;

        }else if(_inputVector.x > 0) 
        {
            _spriteRenderer.flipX = false;
        }
    }


}
