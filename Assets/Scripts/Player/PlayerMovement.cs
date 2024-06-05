using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Player _player;

    private float _moveSpeed = 4f;
    private float _jumpForce = 6f;
    private float _hInput;
    private float _vInput;

    private bool _isGrounded;

    private Rigidbody _rb;
    
    //[SerializeField] private Animator playerAnimator;
    private int comboCounter;
    private bool _isAttacking;
    public Transform tf;
    


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
    }
    
    public void ComboStart()
    {
        _isAttacking = false;
        if (comboCounter < 3)
        {
            comboCounter++;
        }
        
    }
    
    public void ComboEnd()
    {
        _isAttacking = false;
        comboCounter = 0;
    }

    public void Combos()
    {
        if (Input.GetKeyDown(KeyCode.E) && !_isAttacking)
        {
            _isAttacking = true;
           // playerAnimator.SetInteger("Punch", comboCounter);
        }
    }

    void Update()
    {
        
        

        _hInput = Input.GetAxis("Horizontal");
        _vInput = Input.GetAxis("Vertical");

        Move();
        Combos();
        FLip();

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            StartCoroutine(Jump());
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
        if (_hInput < 0)
        {
            _player.playerSpriteRenderer.flipX = true;
            

        }
        else if (_hInput > 0)
        {
            _player.playerSpriteRenderer.flipX = false;
            
        }
    }

    private void Move()
    {
        if (_hInput != 0 || _vInput != 0)
        {
            Vector3 movement = new Vector3(_hInput, 0, _vInput) * _moveSpeed * Time.deltaTime;
            _rb.MovePosition(_rb.position + movement);

            Debug.Log("Moving");
            _player.playerAnimator.SetBool("Walking", true);
        }
        else
        {
            _player.playerAnimator.SetBool("Walking", false);
        }
    }
}
