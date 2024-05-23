using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAenemy : MonoBehaviour,IAttack
{
    [SerializeField] public Transform player;
    [SerializeField] private float distance;
    public Vector3 puntoInicial;
    private SpriteRenderer _spriteRenderer;

    public void Start()
    {
        puntoInicial = transform.position;
    }

    public void Attack()
    {
       
    }

    public void move()
    {
        distance = Vector3.Distance(transform.position, player.position);
        
    }

    public void flip(Vector3 position)
    {
        if (transform.position.x < position.x)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }
}
