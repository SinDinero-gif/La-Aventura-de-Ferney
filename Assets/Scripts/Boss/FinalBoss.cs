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
   [SerializeField] private DataBoss _data;
   
   [Header("IA")]
   [SerializeField] private Transform player;
   [SerializeField] private float followDistance = 20f;
   [SerializeField] private GameObject bornPrefab;
   [SerializeField] private Transform attackPoint;
   [SerializeField] private float ForceJump;
   private bool isGrounded = true;
   private bool canJump = true;
   private bool isAttacking = false;
   private Rigidbody _rb;
   private float _distanceToPlayer;
   private float groundCheckDistance = 5f;
   [SerializeField] private LayerMask suelo;
   private NavMeshAgent _meshAgent;
   
   
   [Header("Animation")]
   [SerializeField] Animator _animator;


   private void Start()
   {
      _data.CurrentHealth = _data.MaxHealth;
      _data.CanAttack = true;
      _meshAgent = GetComponent<NavMeshAgent>();
      _meshAgent.updateRotation = false;
      _rb = GetComponent<Rigidbody>();
      player = GameObject.FindGameObjectWithTag("Player").transform;



   }

   private void Update()
   {
      isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, suelo);
      if(!_data.CanAttack || isAttacking || !isGrounded || !canJump) return;
      //StartCoroutine(RandomAttack(randomIndex:5));
      StartCoroutine(JumpAttack());
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
            
      }
   }

   public IEnumerator BurnAttack()
   {
      _data.CanAttack = false;
        
      //_animator.SetTrigger("Attack");

      yield return new WaitForSeconds(1f);

      Collider[] hitEnemiesR = Physics.OverlapSphere(attackPoint.position, _data.AttackRadius, _data.enemyLayers);

      foreach (Collider player in hitEnemiesR)
      {
         player.GetComponent<Player>().TakeDamage(_data.BurnDamage);
         
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
         yield return new WaitForSeconds(1f);
      }
   }
   

   


   private IEnumerator BiteAttack()
   {
      yield return new WaitForSeconds(5f);
   }

   private IEnumerator JumpAttack()
   {
      canJump = false;
      _meshAgent.enabled = false;
      _rb.AddForce(new Vector3(0, ForceJump, 0), ForceMode.Impulse);
      Vector3 direction = (player.position - transform.position).normalized;
      _rb.AddForce(new Vector3(direction.x * ForceJump, ForceJump, direction.z * ForceJump), ForceMode.VelocityChange);
      _animator.SetTrigger("Jump");
      isGrounded = false;
      yield return new WaitUntil(() => Physics.CheckSphere(transform.position, groundCheckDistance, suelo));
      
      yield return new WaitForSeconds(5f);
      _meshAgent.enabled = true;
      isGrounded = true;
      canJump = true;

   }
   void OnDrawGizmos()
   {
      
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(transform.position, groundCheckDistance);
   }
   
   

}
