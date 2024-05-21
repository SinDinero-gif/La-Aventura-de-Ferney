using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IEntity
{
    private int _maxHealth = 100;
    private int _currentHealth;

    private bool _isAlive = true;
    private bool _tookDamage = false;
    

    [Header("UI")]
    [SerializeField] GameObject _healthCanvas;
    [SerializeField] Image _healthBar;

    [Header("Animation")]
    [SerializeField] Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;

        _healthBar.fillAmount = _currentHealth * 0.01f;
    }

    void Update()
    {
        _healthBar.fillAmount = _currentHealth * 0.01f;

        if (_tookDamage)
        {

            StartCoroutine(DamageAnim());

        }

        if (_isAlive == false)
        {
            _tookDamage = false;

            //Death Animation
            _animator.SetTrigger("Die");
            

            //Disable the Enemy
            StartCoroutine(EnemyDeath());

        }
    }

    private IEnumerator DamageAnim()
    {
        _animator.SetTrigger("Damage");

        yield return new WaitForSeconds(0.1f);

        _tookDamage = false;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _tookDamage = true;

       

        if (_currentHealth <= 0) 
        {
            Die();
            
            
        }

    }

    public void Die()
    {
        _isAlive = false;
        

        Debug.Log("The Enemy is Dead");

        
        

        

    }

    public IEnumerator EnemyDeath()
    {

        yield return new WaitForSeconds(1.5f);

        Destroy(gameObject);
    }
}
