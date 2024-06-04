using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Object Data",menuName = "Object Data")] 
public class ObjectData : ScriptableObject
{
   [SerializeField] private string name;
   [SerializeField] private string description;
   [SerializeField] private int damage;
   [SerializeField] private int health;

   
   public string Name
   {
      get { return name;}
      set { name = value; }
   }

   public string Description
   {
      get { return description; }
      set { description = value; }
   }

   public int DamagePlus
   {
      get { return damage; }
      set { damage = value; }
   }

   public int HealthPlus
   {
      get { return health; }
      set { health = value; }
   }



}
