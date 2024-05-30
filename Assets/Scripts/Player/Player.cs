using System;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour,IEntity
    {
        [Header("Data")]
        [SerializeField] private EntityData _data;

        [Header("Health")]
        private bool _isAlive = true;
        private bool _tookDamage = false;

        private float _fillSpeed = 0.42f;
       
        
        
        
        [Header("SpriteManagement")]  
        [SerializeField] private SpriteRenderer _playerSpriteRenderer;


        private void Start()
        {
            _data.CurrentHealth = _data.MaxHealth;
        }


        public void TakeDamage(int damage)
        {
            _data.CurrentHealth -= damage;
            _tookDamage = true;
        }

        public void Die()
        {
            _isAlive = false;
        }
    }
}