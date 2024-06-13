using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit : MonoBehaviour
{
        private Animator _animator;
        public int damage = 10;

        private void Start()
        {
                _animator = GetComponent<Animator>();
        }

        void OnCollisionEnter(Collision collision)
        {
                var other = collision.collider;
                if (other.CompareTag("Player"))
                {
                        Debug.Log("Proyectil ha colisionado con el jugador.");
                        Player player = other.GetComponent<Player>();
                        if (player != null)
                        {
                                player.TakeDamage(damage);
                                Debug.Log("Daño aplicado: " + damage);
                        }
                        Destroy(gameObject);
                       
                }
                else if (other.CompareTag("Ground"))
                {       
                        _animator.SetTrigger("Ground"); 
                        Destroy(gameObject); 
                }
                
        }

}


