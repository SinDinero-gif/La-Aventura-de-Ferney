using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour, IEntity
{
    [Header("Data")]
    // Updated upstream
    public EntityData _data;
    [SerializeField] private ObjectData _objectData;

    [Header("Health")]
    public bool isAlive = true;
    private bool _tookDamage = false;
    
    [Header("Health UI")]
    [SerializeField] private GameObject _healthBar;
    [SerializeField] Image _empanada1;
    [SerializeField] Image _empanada2;
    [SerializeField] Image _empanada3;
    
    [Header("Player UI Management")]
    [SerializeField] Sprite _empanadaFull;
    [SerializeField] Sprite _empanadaHalf;
    [SerializeField] Sprite _empanadaEmpty;
    
    [Header("SpriteManagement")]
    [SerializeField] private SpriteRenderer _playerSpriteRenderer;
    public SpriteRenderer playerSpriteRenderer => _playerSpriteRenderer;

    [Header("Animation")]
    public Animator playerAnimator;

    private static Player _instance;
    public static Player Instance => _instance;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _data.CurrentHealth = _data.MaxHealth;
    }
    
    public void Update()
    {
       _data.CurrentHealth = Math.Clamp(_data.CurrentHealth, 0, _data.MaxHealth);

        if (!isAlive)
        {
            Die();
            Debug.Log("The " + _data.Name + " is Dead");
            Enemy.Instance.navMeshAgent.isStopped = true;

        }
        else
        {
            
        }

    }
    
    
    public void TakeDamage(int damage)
    {
        _data.CurrentHealth -= damage;
        _tookDamage = true;

        Debug.Log(_data.Name + " ha recibido 15 de daño");
        Debug.Log(_data.CurrentHealth);
    
    
        if (_data.CurrentHealth <= 0)
        {
            isAlive = false;
            
        }
    }
    
    public void Die()
    {
        _tookDamage = false;

        playerAnimator.SetTrigger("Die");

        Time.captureDeltaTime = 0;
    }
    
    
}
