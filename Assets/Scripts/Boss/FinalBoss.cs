using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.Mathematics;
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
   [SerializeField] private GameObject bornPrefab;
   [SerializeField] private Transform attackPoint;
   private float distanceToPlayer;
   private NavMeshAgent _meshAgent;
   
   
   [Header("Animation")]
   [SerializeField] Animator _animator;


   private void Start()
   {
      _data.CurrentHealth = _data.MaxHealth;
      _data.CanAttack = true;
      _meshAgent = GetComponent<NavMeshAgent>();
      _meshAgent.updateRotation = false;
      StartCoroutine(SpitAttack());


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

         if (distanceToPlayer <= 10f & _data.CanAttack)
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
            {
               SpitAttack();
            }
            break;
         case 1 :
            {
               BurnAttack();
            }
            break;
         case 2:
            BiteAttack();
            break;
         case 3:
            JumpAttack();
            break;
            
      }
   }

   public IEnumerator BurnAttack()
   {
      _data.CanAttack = false;
        
      _animator.SetTrigger("Attack");

      yield return new WaitForSeconds(1f);

      Collider[] hitEnemiesR = Physics.OverlapSphere(attackPoint.position, _data.AttackRadius, _data.enemyLayers);

      foreach (Collider player in hitEnemiesR)
      {
         player.GetComponent<Player>().TakeDamage(_data.PunchDamage);
         
      }

      yield return new WaitForSeconds(1f);

      _data.CanAttack = true;

   }


   public IEnumerator SpitAttack()
   {
      while (true)
      {
            GameObject born = Instantiate(bornPrefab, transform.position, quaternion.identity);
            Rigidbody rb = born.GetComponent<Rigidbody>();
            Vector3 direction = (player.transform.position - transform.position).normalized;
            Collider[] hitEnemiesR = Physics.OverlapSphere(attackPoint.position, _data.AttackRadius, _data.enemyLayers);

            foreach (Collider player in hitEnemiesR)
            {
               player.GetComponent<Player>().TakeDamage(_data.PunchDamage);
         
            }
            rb.AddForce(direction * 1000);
            yield return new WaitForSeconds(7f);
      }
        
   }
   

   


   private void BiteAttack()
   {
      
   }

   private void JumpAttack()
   {
      
   }

}
