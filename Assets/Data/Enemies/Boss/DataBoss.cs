using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "Boss",menuName ="Boss",order = 1)]
public class DataBoss : ScriptableObject
{
   [SerializeField] private int _id;
   
   [SerializeField] private string name;

   [SerializeField] private int _burnDamage;

   [SerializeField] private int _jumpDamage;

   [SerializeField] private int _biteDamage;

   [SerializeField] private int _spitDamage;
   
   [SerializeField] private float _attackRadius;

   [SerializeField] private int _currentHealth;

   [SerializeField] private int _maxCurrentHealth;

   private bool _canAttack;
   
   public int Id
   {
      get => _id;
      set => _id = value;
        
   }

   public string Name
   {
      get { return name; }
      set { name = value; }
   }

   public int BurnDamage
   {
      get => _burnDamage;
      set
      {
         if (_burnDamage > 10)
         {
            _burnDamage = 10;
         }
         else
         {
            _burnDamage = value;
         }
      }
   }

   public int JumpDamage
   {
      get => _jumpDamage;
      set
      {
         if (_jumpDamage > 20)
         {
            _jumpDamage = 10;
         }
         else
         {
            _jumpDamage = value;
         }
      }
   }

   public int BiteDamage
   {
      get => _biteDamage;
      set
      {
         if (_biteDamage > 10)
         {
            _biteDamage = 10;
         }
         else
         {
            _biteDamage = value;
         }
      }
   }

   public int SpitDamage
   {
      get => _spitDamage;
      set
      {
         if (_spitDamage > 20)
         {
            _spitDamage = 20;
         }
         else
         {
            _spitDamage = value;
         }
      }
   }
   public float AttackRadius
   {
      get => _attackRadius;
      set {  _attackRadius = value; }
   }
   public LayerMask enemyLayers;
   public int MaxHealth
   {
      get => _maxCurrentHealth;
      set { _maxCurrentHealth = value; }
   }

   public int CurrentHealth
   {
      get => _currentHealth;
      set { _currentHealth = value; }
   }
   public bool CanAttack
   {
      get => _canAttack;
      set { _canAttack = value; }
   }
}
