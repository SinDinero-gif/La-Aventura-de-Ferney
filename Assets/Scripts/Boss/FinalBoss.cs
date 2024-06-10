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
   [SerializeField] private float ForceJump;
   //private bool isGrounded = true;
   private bool isAttacking = false;
   private Rigidbody rb;
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
      rb = GetComponent<Rigidbody>();
      player = GameObject.FindGameObjectWithTag("Player").transform;



   }

   private void Update()
   {
      
      if(!_data.CanAttack || isAttacking) return;
      StartCoroutine(RandomAttack(randomIndex:5));
      Movement();


   }

   private void Movement()
   {
      float distance = Vector3.Distance(transform.position, player.position);
      //isGrounded = true;
      RaycastHit hit;
      if (distance < followDistance)
      {
         Jump();
      }
   }

   private void Jump()
   {
      rb.AddForce(Vector3.up * ForceJump);
   }

   private IEnumerator RandomAttack(int randomIndex)
   {
      randomIndex = Random.Range(1, 5);
      
      int attackNumber = randomIndex;
      switch (attackNumber)
      {
         case 0 :
            yield return StartCoroutine(SpitAttack());
            break;
         case 1 :
              yield return StartCoroutine(BurnAttack());
            break;
         case 2:
            yield return StartCoroutine(BiteAttack());
            break;
         case 3:
            yield return StartCoroutine(JumpAttack());
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
         _animator.SetTrigger("AttackSpirit");
         GameObject spit = Instantiate(bornPrefab, transform.position, Quaternion.identity);
         Rigidbody rb = spit.GetComponent<Rigidbody>();
         Vector3 direction = (player.transform.position - transform.position).normalized;
         Spit spitA = spit.AddComponent<Spit>();
         spitA.damage = 10; 
         rb.AddForce(direction * 4000);
         yield return new WaitForSeconds(7f);
      }
   }
   

   


   private IEnumerator BiteAttack()
   {
      yield return new WaitForSeconds(5f);
   }

   private IEnumerator JumpAttack()
   {
      yield return new WaitForSeconds(5f);
   }

}
