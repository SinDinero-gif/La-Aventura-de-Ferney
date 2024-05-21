using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hadouken : MonoBehaviour,IAttack
{
   [SerializeField] private float maxRange;
   private float cooldownTime = 3f;
   private float lastAtack;
   [SerializeField] private int AttackDamage;
   private RaycastHit[] hits;


   public void Start()
   {
        lastAtack = -cooldownTime;
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
       hits = Physics.RaycastAll(ray, maxRange); 
       Debug.DrawRay(ray.origin, ray.direction * maxRange, Color.red);

       foreach (RaycastHit hit in hits)
       {
           hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;
       }
   }

}
