using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class FinalBoss : MonoBehaviour
{
   [Header("Data")]
   [SerializeField] private EntityData _data;
   
   [Header("IA")]
   [SerializeField] private Transform player;
   [SerializeField] private float followDistance = 5f;
   private NavMeshAgent _meshAgent;
   
   [Header("Animation")]
   [SerializeField] Animator _animator;


   private void Start()
   {
      _data.CurrentHealth = _data.MaxHealth;
      _data.CanAttack = true;
      _meshAgent = GetComponent<NavMeshAgent>();
      _meshAgent.updateRotation = false;

   }

   private void Update()
   {
      Movement();
      RandomAttack(randomIndex:0);
      
   }

   private void Movement()
   {
      float distanceToPlayer = Vector3.Distance(transform.position, player.position);

      if (distanceToPlayer < followDistance) 
      {
         _meshAgent.SetDestination(player.position);

         if (distanceToPlayer <= 1f & _data.CanAttack)
         {
                
         }

      }
   }

   private void RandomAttack(int randomIndex)
   {
      randomIndex = Random.Range(1, 5);
      
      int attackNumber = randomIndex;
      switch (attackNumber)
      {
         case 0 :
            SpitAttack();
            break;
         case 1 : 
            BornAtack();
            break;
         case 2:
            BiteAttack();
            break;
            
            
      }
   }

   private void SpitAttack()
   {
      
   }

   private void BornAtack()
   {
      
   }

   private void BiteAttack()
   {
      
   }
   
}
