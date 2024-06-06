using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Object Data",menuName = "Object Data")] 
public class ObjectData : ScriptableObject
{
   [SerializeField] private string _name;
   [SerializeField] private string _description;
   [SerializeField] private int _dataAttack;
   [SerializeField] private int _dataHealth;

   
   public string Name
   {
      get { return _name;}
      set { _name = value; }
   }

   public string Description
   {
      get { return _description; }
      set { _description = value; }
   }

   public int DamagePlus
   {
      get { return _dataAttack; }
      set { _dataAttack = value; }
   }

   public int HealthPlus
   {
      get { return _dataHealth; }
      set { _dataHealth = value; }
   }



}
