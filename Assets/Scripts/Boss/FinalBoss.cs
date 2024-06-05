using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

public class FinalBoss : MonoBehaviour
{
  
    [Header("Data")]
    [SerializeField] private EntityData _data;

    [Header("AI")]
    [SerializeField] private Transform player;
    [SerializeField] private float followDistance = 5f;
    [SerializeField] private Transform atackPoint;
    [SerializeField] private GameObject ScupidPrefab;
    private NavMeshAgent _navMeshAgent;

    [Header("Animation")] 
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _data.MaxHealth = _data.CurrentHealth;
        _data.CanAttack = true;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;

    }

    private void Update()
    {
        Movement();
        RandomAttack();
    }

    
    public void Movement()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer < followDistance) 
        {
            _navMeshAgent.SetDestination(player.position);

            if (distanceToPlayer <= 1f & _data.CanAttack)
            {
                
            }

        }
        
    }


    private void RandomAttack()
    {
        

    }
    private void ScupidAttack()
    {
        
    }

    private void JumpAttack()
    {
        
    }

    private void burnAttack()
    {
        
    }
    
}
