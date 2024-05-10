using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private float _moveSpeed = 2f;

    private Rigidbody _rb;
    [SerializeField] private Animator _playeranimator;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetAxis("Horizontal")) 
        {
            MoveHorizontal();
        }

        if (Input.GetAxis("Vertical"))
        {
            MoveVertical();
        }
    }

    private void MoveHorizontal()
    {
        _rb.velocity = new Vector3(_rb.velocity.x * _moveSpeed, _rb.velocity.y, _rb.velocity.z);
    }

    private void MoveVertical() 
    {
        _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, _rb.velocity.z * _moveSpeed);
    }
}
