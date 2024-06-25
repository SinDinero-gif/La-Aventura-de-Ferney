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

    public EnemyType enemyType;

    private float _fillSpeed = 0.42f;
    [SerializeField] 
    private Gradient _colorGradient;
    
    [Header("AI")]
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float followDistance = 5f;
    [SerializeField] private Transform attackPoint;
    public NavMeshAgent navMeshAgent;

    [SerializeField]
    private float _attackRadius;

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
        
        _healthBar.fillAmount = _data.CurrentHealth / _data.MaxHealth;

        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
    }

    void Update()
    {

        if (!Player.Instance.isAlive || !_isAlive)
        {
            Distance = 100f;
        } else
        {
            Distance = Vector3.Distance(transform.position, _playerTransform.position);
        }
        _animator.SetFloat("Distance",Distance);
        

        

        FlipSprite(_playerTransform.position);

        Movement();

        if (Distance <= 1f & _data.CanAttack)
        {
            StartCoroutine(Attack());

        }

    }

    public void Movement()
    {
        if (Distance < followDistance)
        {
            navMeshAgent.SetDestination(_playerTransform.position);
        }
    }

    public IEnumerator Attack()
    {

        Debug.Log(_data.Name + " ataca a Ferney!");
        _data.CanAttack = false;
        
        _animator.SetTrigger("Attack");

        if(enemyType == EnemyType.Rata)
        {
            AudioManager.Instance.PlayEnemySFX("Rata Attack");

        }else if(enemyType == EnemyType.Kukaracha)
        {
            AudioManager.Instance.PlayEnemySFX("Kukaracha Attack");
        }

        yield return new WaitForSeconds(1.6f);

        Collider[] hitEnemiesR = Physics.OverlapSphere(attackPoint.position, _attackRadius, _data.enemyLayers);

        foreach (Collider player in hitEnemiesR)
        {
            player.GetComponent<Player>().TakeDamage(_data.Damage - 5);
            AudioManager.Instance.PlayPlayerSFX("Player Hurt");
            Debug.Log(_data.Name + " ha atacado a Ferney!, haciendo " + _data.Damage + " de da�o");
        }

        yield return new WaitForSeconds(3f);

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
        _data.CanAttack = false;

        if (enemyType == EnemyType.Rata)
        {
            AudioManager.Instance.PlayEnemySFX("Rata Damaged");

        }
        else if (enemyType == EnemyType.Kukaracha)
        {
            AudioManager.Instance.PlayEnemySFX("Kukaracha Damaged");
        }


        _animator.SetTrigger("Damaged");

        yield return new WaitForSeconds(1.5f);

        
        
        _data.CanAttack = true;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log(_data.Name + " ha sido herido");

        StartCoroutine(DamageAnim());

        _data.CurrentHealth -= damage;


        float targetFillAmount = _data.CurrentHealth * 0.01f;
        _healthBar.DOFillAmount(targetFillAmount, _fillSpeed);
        _healthBar.DOColor(_colorGradient.Evaluate(targetFillAmount), _fillSpeed);



        if (_data.CurrentHealth <= 0) 
        {
            _data.CanAttack = false;
            navMeshAgent.isStopped = true;
            StartCoroutine(EnemyDeath());
        }

    }

    public IEnumerator EnemyDeath()
    {
        _animator.SetTrigger("Die");

        if (enemyType == EnemyType.Rata)
        {
            AudioManager.Instance.PlayEnemySFX("Rata Die");

        }
        else if (enemyType == EnemyType.Kukaracha)
        {
            AudioManager.Instance.PlayEnemySFX("Kukaracha Die");
        }

        yield return new WaitForSeconds(8f);

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(attackPoint.position, _attackRadius);

    }
}
