using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hadouken : MonoBehaviour,IAttack
{
   [SerializeField] private float maxRange;
   private float cooldownTime = 10f;
   private float lastAtack;
   [SerializeField] private int AttackDamage;
   private RaycastHit[] hits;


   public void Start()
   {
       float lastAtack = -cooldownTime;
   }

   public void Update()
   {
       
       if (Time.time - lastAtack >= cooldownTime)
       {


           if (Input.GetKey(KeyCode.A))
           {
               Atack();
               lastAtack = Time.time;

           }
       }
   }

   public void Atack()
   {
     Ray ray = new Ray(transform.position, transform.forward);
     hits = Physics.RaycastAll(ray);
     foreach (RaycastHit hit in hits)
     {
         hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
         hit.transform.gameObject.GetComponent<Enemy>().TakeDamage(AttackDamage);
     }

   }
}
