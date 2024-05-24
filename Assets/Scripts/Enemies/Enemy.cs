using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IEntity
{
    [Header("Health")]
    private float _maxHealth = 100.0f;
    private float _currentHealth;

    private bool _isAlive = true;
    private bool _tookDamage = false;

    private float _fillSpeed = 0.42f;
    [SerializeField] 
    private Gradient _colorGradient;

    [Header("SpriteManagement")]

    [SerializeField] private Transform _playerTransform;
    [SerializeField] private SpriteRenderer _enemySprite;

    [Header("UI")]
    [SerializeField] GameObject _healthCanvas;
    [SerializeField] Image _healthBar;

    [Header("Animation")]
    [SerializeField] Animator _animator;
    

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
        _healthBar.fillAmount = _currentHealth / _maxHealth;
    }

    void Update()
    {
       
        
        

        
        if (_tookDamage)
        {

            StartCoroutine(DamageAnim());
            
        }

        if (_isAlive == false)
        {
            _tookDamage = false;
            _animator.SetBool("Damaged", false);

            //Death Animation
            _animator.SetTrigger("Die");
            

            //Disable the Enemy
            StartCoroutine(EnemyDeath());

        }

        FlipSprite();

       


    }

   

    private void FlipSprite()
    {
        Vector3 directionToPlayer = _playerTransform.position - transform.position;

        _enemySprite.flipX = directionToPlayer.x < 0;

    }

    private IEnumerator DamageAnim()
    {
        _animator.SetBool("Damaged", true);

        yield return new WaitForSeconds(0.1f);

        _animator.SetBool("Damaged", false);
        _tookDamage = false;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _tookDamage = true;

        float targetFillAmount = _currentHealth / _maxHealth;
        _healthBar.DOFillAmount(targetFillAmount, _fillSpeed);
        _healthBar.DOColor(_colorGradient.Evaluate(targetFillAmount), _fillSpeed);


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
