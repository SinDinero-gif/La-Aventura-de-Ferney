using System;
using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IEntity
{
   
    [Header("Data")]
    [SerializeField] private EntityData _data;

    [Header("Health")]
    private bool _isAlive = true;
    private bool _tookDamage = false;

    private float _fillSpeed = 0.42f;
    [SerializeField] 
    private Gradient _colorGradient;
    
    [Header("AI")]
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float followDistance = 5f;
    [SerializeField] private Transform attackPoint;
    public NavMeshAgent navMeshAgent;

    [Header("SpriteManagement")]  
    [SerializeField] private SpriteRenderer _enemySprite;

    [Header("UI")]
    [SerializeField] GameObject _healthCanvas;
    [SerializeField] Image _healthBar;

    [Header("Animation")]
    [SerializeField] Animator _animator;

    [SerializeField] private float Distance;

    private static Enemy _instance;

    public static Enemy Instance => _instance;

    void Awake()
    {
        _instance = this;
        _animator.SetInteger("Active", 1);
    }
   

    
    void Start()
    {

        _data.CurrentHealth = _data.MaxHealth;
        _data.CanAttack = true;
        
        _healthBar.fillAmount = _data.CurrentHealth * _data.MaxHealth;

        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
    }

    void Update()
    {
        Distance = Vector3.Distance(transform.position, _playerTransform.position);
        _animator.SetFloat("Distance",Distance);
        
        if (_tookDamage)
        {
            StartCoroutine(DamageAnim());
        }

        

        if (_isAlive == false)
        {
            _data.CanAttack = false;
            _tookDamage = false;
            navMeshAgent.isStopped = true;

            //Death Animation
            _animator.SetTrigger("Die");


            //Disable the Enemy
            StartCoroutine(EnemyDeath());

        }

        FlipSprite(_playerTransform.position);

        Movement();

        if(Player.Instance.isAlive == false)
        {
            _animator.SetInteger("Active", 0);
        }
        else
        {
            _animator.SetInteger("Active", 1);
        }

    }

    public void Movement()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _playerTransform.position);

        if (distanceToPlayer < followDistance) 
        {
            navMeshAgent.SetDestination(_playerTransform.position);

            if (distanceToPlayer <= 1f & _data.CanAttack)
            {
                StartCoroutine(Attack());
                
            }

        }
        

    }

    public IEnumerator Attack()
    {
        Debug.Log(_data.Name + " ataca a Ferney!");
        _data.CanAttack = false;
        
        _animator.SetTrigger("Attack");

        yield return new WaitForSeconds(0.4f);

        Collider[] hitEnemiesR = Physics.OverlapSphere(attackPoint.position, _data.AttackRadius, _data.enemyLayers);

        foreach (Collider player in hitEnemiesR)
        {
            player.GetComponent<Player>().TakeDamage(_data.PunchDamage);
            Debug.Log(_data.Name + " ha atacado a Ferney!, haciendo " + _data.PunchDamage + " de da�o");
        }

        yield return new WaitForSeconds(2f);

        _data.CanAttack = true;
        
    }

    public void FlipSprite(Vector3 playerPosition)
    {
        if (transform.position.x < playerPosition.x)
        {
            _enemySprite.flipX = false;
        }
        else
        {
            _enemySprite.flipX = true;
        }
    }


    private IEnumerator DamageAnim()
    {
        _animator.SetBool("Damaged", true);
        _data.CanAttack = false;

        yield return new WaitForSeconds(2f);

        _animator.SetBool("Damaged", false);
        _tookDamage = false;
        _data.CanAttack = true;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(_data.Name + " ha sido herido");

        _data.CurrentHealth -= damage;
        _tookDamage = true;
        _animator.SetTrigger("Attack");


        float targetFillAmount = _data.CurrentHealth * 0.01f;
        _healthBar.DOFillAmount(targetFillAmount, _fillSpeed);
        _healthBar.DOColor(_colorGradient.Evaluate(targetFillAmount), _fillSpeed);



        if (_data.CurrentHealth <= 0) 
        {
            Die();
            navMeshAgent.Stop();
                     
        }

    }

    public void Die()
    {
        _isAlive = false;
        

        Debug.Log("The " + _data.Name + " is Dead");
        

    }

    public IEnumerator EnemyDeath()
    {

        yield return new WaitForSeconds(1.5f);

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(attackPoint.position, _data.AttackRadius);

    }
}
