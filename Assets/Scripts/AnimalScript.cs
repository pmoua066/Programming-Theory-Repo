using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalScript : MonoBehaviour
{
    public float fullness;
    
    void Start()
    {
        fullness = 100;
        InvokeRepeating("GetHungry", 1, 1);
    }

   
    void Update()
    {
        
    }

    public virtual void GetHungry()
    {
        fullness -= 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food") && fullness < 90)
        {
            fullness += 10;
        }
        else
        {
            fullness = 100;
        }
    }
}
