using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalScript : MonoBehaviour
{
    public float hunger;
    
    void Start()
    {
        hunger = 100;
        InvokeRepeating("GetHungry", 1, 1);
    }

   
    void Update()
    {
        
    }

    public virtual void GetHungry()
    {
        hunger -= 1;
    }    
}
