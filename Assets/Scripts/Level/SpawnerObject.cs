using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpawnerObject : MonoBehaviour
{
   [SerializeField] private GameObject Object;

   private void Start()
   {
      StartCoroutine(Spawner());
   }

   public IEnumerator Spawner()
   {
      while (true)
      {
         Instantiate(Object, transform.position, quaternion.identity);
         yield return new WaitForSeconds(15);
      }
   }
}
