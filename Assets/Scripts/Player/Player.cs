using System;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class Player : MonoBehaviour,IEntity
    {
        [Header("Data")]
<<<<<<< Updated upstream
        [SerializeField] private EntityData _data;
        [SerializeField] private ObjectData _objectData;
=======
        public EntityData _data;
>>>>>>> Stashed changes

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

        public bool TookDamage { get => _tookDamage;}

        private void Start()
        {
            _data.CurrentHealth = _data.MaxHealth;
        }

        public void Update()
        {

        }


        public void TakeDamage(int damage)
        {
            _data.CurrentHealth -= damage;
            _tookDamage = true;
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
}