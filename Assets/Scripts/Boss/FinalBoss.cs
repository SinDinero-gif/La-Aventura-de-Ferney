using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class FinalBoss : MonoBehaviour, IEntity
{
   [Header("Data")]
   [SerializeField] private DataBoss _data;
   
   [Header("IA")]
   [SerializeField] private Transform player;
   [SerializeField] private float followDistance = 20f;
   [SerializeField] private GameObject bornPrefab;
   [SerializeField] private Transform attackPoint;
   [SerializeField] private float ForceJump;
   [SerializeField] private float attackRange;
   [SerializeField] private Transform pointSpit;
   private bool _tookDamage = false;
   private bool _isAlive = true;
   private bool isGrounded = true;
   private bool canJump = true;
   private bool isAttacking = false;
   private Rigidbody _rb;
   private float _distanceToPlayer;
   private float groundCheckDistance = 1f;
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
      print(_data.Name + " salud inicial: " + _data.CurrentHealth);
      
   }

   private void Update()
   {
      _data.CurrentHealth = Math.Clamp(_data.CurrentHealth, 0, _data.MaxHealth);
      isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, suelo);
      if(!_data.CanAttack || isAttacking || !isGrounded || !canJump) return;
      StartCoroutine(JumpAttack());
   }
   
      
   public void TakeDamage(int damage)
   {
      StartCoroutine(DamageAnim());
      _data.CurrentHealth -= damage;
      _tookDamage = true;

     
      print(_data.Name + " ha recibido " + damage + " de daño");
      print(_data.Name + " salud restante: " + _data.CurrentHealth);
      
    
      if (_data.CurrentHealth <= 0)
      {
         _isAlive = false;
         Destroy(gameObject);
            
      }
   }

   private IEnumerator DamageAnim()
   {
      _data.CanAttack = false;
      
      _animator.SetBool("Damage",true);
      yield return new WaitForSeconds(0.20f);
      _animator.SetBool("Damage", false);
      _data.CanAttack = true;
   }

   

   private IEnumerator JumpAttack()
   {
      canJump = false;
      _meshAgent.enabled = false;
      _rb.AddForce(new Vector3(0, ForceJump, 0), ForceMode.Impulse);
      Vector3 direction = (player.position - transform.position).normalized;
      _rb.AddForce(new Vector3(direction.x * ForceJump, ForceJump, direction.z * ForceJump), ForceMode.VelocityChange);
      _animator.SetBool("Jump",true);
      isGrounded = false;
      
      yield return new WaitUntil(() => _rb.velocity.y < 0);

      
      yield return new WaitUntil(() => Physics.CheckSphere(transform.position, groundCheckDistance, suelo));
      _animator.SetBool("Jump", false);
      _animator.SetBool("Fall", true);

      yield return new WaitForSeconds(1f); 
      _animator.SetBool("Fall", false);
      _animator.SetBool("Idle", true);

      yield return new WaitForSeconds(5f);
      _animator.SetBool("Idle", false);
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
