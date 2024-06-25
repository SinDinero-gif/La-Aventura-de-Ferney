using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empanada : MonoBehaviour
{
    [SerializeField] private int vida;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("tienes mas vida puto");
            Player data = other.gameObject.GetComponent<Player>();
            if (data != null)
            {
                data._data.CurrentHealth += vida; 
                Destroy(gameObject);
            }
            
        }
    }
}
