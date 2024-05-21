using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HighKick : MonoBehaviour,IAttack
{
    [SerializeField] private float damageKick;
    private float kickCold = 0f;
    private float lastKick;
   

    private void Start()
    {
        float lastKick = -kickCold;
    }


    private void Update()
    {
        if (Time.time - lastKick >= kickCold)
        {


            if (Input.GetKey(KeyCode.A))
            {
                Attack();
                lastKick = Time.time;
            }
        }
    }

    void Attack()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin,ray.direction*30,Color.red);

        if (Physics.Raycast(ray, out hit))
        {
            hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            hit.transform.gameObject.GetComponent<Enemy>().TakeDamage(20);
        }
    }
}
