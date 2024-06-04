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
        HealthCheck();
        
    }
    
    
    public void TakeDamage(int damage)
    {
        _data.CurrentHealth -= damage;
        _tookDamage = true;
        
        Debug.Log(_data.Name + " ha recibido 15 de daño");
    
    
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
    
    public void HealthCheck()
    {
        switch (_data.CurrentHealth)
        {
            case 0:
                if (_data.CurrentHealth >= 85.7f)
                {
                    _empanada1.sprite = _empanadaFull;
                    _empanada2.sprite = _empanadaFull;
                    _empanada3.sprite = _empanadaFull;
                }
                break;
            case 1:
                if (_data.CurrentHealth < 85.7f)
                {
                    _empanada1.sprite = _empanadaHalf;
                    _empanada2.sprite = _empanadaFull;
                    _empanada3.sprite = _empanadaFull;
                }
                break;
            case 2:
                if (_data.CurrentHealth < 71.4f)
                {
                    _empanada1.sprite = _empanadaEmpty;
                    _empanada2.sprite = _empanadaFull;
                    _empanada3.sprite = _empanadaFull;
                }
                break;
            case 3:
                if (_data.CurrentHealth < 57.1f)
                {
                    _empanada1.sprite = _empanadaEmpty;
                    _empanada2.sprite = _empanadaHalf;
                    _empanada3.sprite = _empanadaFull;
                }                    
                break;
            case 4:
                if (_data.CurrentHealth < 42.8f)
                {
                    _empanada1.sprite = _empanadaEmpty;
                    _empanada2.sprite = _empanadaEmpty;
                    _empanada3.sprite = _empanadaFull;
                }                    
                break;
            case 5:
                if (_data.CurrentHealth < 28.5)
                {
                    _empanada1.sprite = _empanadaEmpty;
                    _empanada2.sprite = _empanadaEmpty;
                    _empanada3.sprite = _empanadaHalf;
                }                    
                break;
            case 6:
                if (_data.CurrentHealth <= 0)
                {
                    _empanada1.sprite = _empanadaEmpty;
                    _empanada2.sprite = _empanadaEmpty;
                    _empanada3.sprite = _empanadaEmpty;
                }                    
                break;
        }
    }
}
