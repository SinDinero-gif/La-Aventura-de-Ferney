using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, ITakeDamage, IDead
{
    private int _maxHealth = 100;
    private int _currentHealth;

    [Header("UI")]
    [SerializeField] Image _healthbar;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;

        _healthbar.fillAmount = _currentHealth * 0.01f;
    }

    void Update()
    {
        _healthbar.fillAmount = _currentHealth * 0.01f;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0) 
        {
            Die();
        }

    }

    public void Die()
    {
        Debug.Log("The Enemy is Dead");

        //Death Animation

        //Disable the Enemy
    }

}
