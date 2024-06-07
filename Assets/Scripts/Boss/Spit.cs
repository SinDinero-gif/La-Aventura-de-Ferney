using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spit : MonoBehaviour
{
        public int damage = 10; 

        void OnTriggerEnter(Collider other)
        {
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
        }

}


