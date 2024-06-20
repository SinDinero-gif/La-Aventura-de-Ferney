using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class Player : MonoBehaviour, IEntity
{
    [Header("Data")]
    // Updated upstream
    public EntityData _data;
    [SerializeField] private ObjectData _objectData;

    [Header("Health")]
    public bool isAlive = true;
    private bool _tookDamage = false;
    
    [Header("SpriteManagement")]
    [SerializeField] private SpriteRenderer _playerSpriteRenderer;

    [Header("Animation")]
    public Animator playerAnimator;
    
    public GameObject gameOverPanel;

    private static Player _instance;
    public static Player Instance => _instance;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _data.CurrentHealth = _data.MaxHealth;
        
        gameOverPanel.SetActive(false);
        
    }
    
    public void Update()
    {
        _data.CurrentHealth = Math.Clamp(_data.CurrentHealth, 0, _data.MaxHealth);

        if (!isAlive)
        {
            StartCoroutine(DieAnimation());
            Debug.Log("The " + _data.Name + " is Dead");
            if (Enemy.Instance != null && Enemy.Instance.navMeshAgent != null)
            {
                Enemy.Instance.navMeshAgent.isStopped = true;
            }
            else
            {
                Debug.Log("Enemy.Instance o Enemy.Instance.navMeshAgent es null");
            }
        }
        else
        {
            // ...
        }
    }
    
    
    public void TakeDamage(int damage)
    {
        _data.CurrentHealth -= damage;
        _tookDamage = true;
        playerAnimator.SetTrigger("Damaged");

        Debug.Log(_data.Name + " ha recibido 15 de daño");
        Debug.Log(_data.CurrentHealth);
    
    
        if (_data.CurrentHealth <= 0)
        {
            StartCoroutine(DieAnimation());
            _data.CanAttack = false;

        }
    }
    
    private IEnumerator DieAnimation()
    {
        Debug.Log("Mataron a Ferney! Hijos de Puta!");
        _tookDamage = false;

        playerAnimator.SetTrigger("Die");
        yield return new WaitForSeconds(3f);
        
        Die();

    }

    public void Die()
    {
        gameOverPanel.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ZoneDead"))
        {
            Die();
        }
    }
}
