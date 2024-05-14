using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private float _moveSpeed = 2f;
    private float _hInput;
    private float _vInput;

    private Rigidbody _rb;
    
    [SerializeField] private Animator playerAnimator;
    private int comboCounter;
    private bool _isAttacking;

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
            playerAnimator.SetInteger("Punch", comboCounter);
        }
    }

    void Update()
    {
        _hInput = Input.GetAxis("Horizontal");
        _vInput = Input.GetAxis("Vertical");

        Move();
        Combos();
    }

    private void Move()
    {
        if (_hInput != 0 || _vInput != 0)
        {
            Vector3 movement = new Vector3(_hInput, 0, _vInput) * _moveSpeed * Time.deltaTime;
            _rb.MovePosition(_rb.position + movement);

            Debug.Log("Moving");
        }
    }
}
