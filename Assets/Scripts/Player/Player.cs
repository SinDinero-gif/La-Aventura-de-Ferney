using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour,IEntity
{   
    [Header("Data")]
    // Updated upstream
    public EntityData _data;
    [SerializeField] private ObjectData _objectData;
    Player _instance;
    
    [Header("Health")]
    private bool _isAlive = true;
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
    
    public Player Instance
    {
        get; set;
    }
    
    public bool TookDamage { get => _tookDamage;}
    
    private void Start()
    {
        _data.CurrentHealth = _data.MaxHealth;
    }
    
    public void Update()
    {
       _data.CurrentHealth = Math.Clamp(_data.CurrentHealth, 0, _data.MaxHealth);
        
    }
    
    
    public void TakeDamage(int damage)
    {
        _data.CurrentHealth -= damage;
        _tookDamage = true;
        
        Debug.Log(_data.Name + " ha recibido 15 de daño");
        Debug.Log(_data.CurrentHealth);
    
    
        if (_data.CurrentHealth <= 0)
        {
           Die();
           Debug.Log("The " + _data.Name + " is Dead");
            
        }
    }
    
    public void Die()
    {
        _isAlive = false;
    }
    
    
}
