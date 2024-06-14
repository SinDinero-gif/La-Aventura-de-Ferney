using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BarraDeVidaBoss : MonoBehaviour
{
   private Slider Slider;

   private void Start()
   {
      Slider = GetComponent<Slider>();
   }

   public void ChangeLifeMax(float MaxLife)
   {
      Slider.maxValue = MaxLife;
      
   }

   public void ChangeCurrentLife(float CurrentLife)
   {
      Slider.value = CurrentLife;
   }

   public void InicializarBarra(float Cantidad)
   {
      ChangeCurrentLife(Cantidad);
      ChangeLifeMax(Cantidad);
   }
   
}
