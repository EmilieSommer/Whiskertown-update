using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{

   public virtual void MakeSound()
   {
       Debug.Log("Animal sound");
   }

   public virtual void Walk()
   {
         Debug.Log("Animal walk");
   }
    
}
