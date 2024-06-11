using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _animator;


    private float _moveSpeed = 4f;
    [SerializeField] private float _jumpForce = 20f;

    [Header("Ground Check")]
    public Transform groundChekPos;   
    public LayerMask groundLayer;

    private Rigidbody _rb;
    private PlayerInputs _playerInputActions;

    private Vector2 _inputVector;




    void Awake()
    {
        _rb = GetComponent<Rigidbody>();

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
        _inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (IsGrounded() && context.performed)
        {
            StartCoroutine(JumpMethod());
        }
    }

    private IEnumerator JumpMethod()
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _player.playerAnimator.SetBool("Jump", true);

        yield return new WaitForSeconds(0.3f);

        _player.playerAnimator.SetBool("Jump", false);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(groundChekPos.position, Vector3.down, 0.12f, groundLayer);
    }
        

    void Update()
    {
        Move();

        Flip();

        IsGrounded();

        if (IsGrounded())
        {
            _player.playerAnimator.SetBool("Grounded", true);
        }
        else
        {
            _player.playerAnimator.SetBool("Grounded", false);
        }
    }

    private void Move()
    {
        _inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();
        _rb.velocity = new Vector3(_inputVector.x * _moveSpeed, _rb.velocity.y, _inputVector.y * _moveSpeed);

        if (_inputVector.x != 0 && _inputVector.y != 0)
        {
            _player.playerAnimator.SetBool("Walking", true);
        }
        else
        {
            _player.playerAnimator.SetBool("Walking", false);
        }
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
