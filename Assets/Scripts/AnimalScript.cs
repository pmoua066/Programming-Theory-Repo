using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalScript : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private int m_fullness;
    public int fullness 
    { 
        get { return m_fullness; } 
        set
        {
            if ( value > 100.0f)
            {
                Debug.Log("The animal is full");
                value = 100;
            }
            else
            {
                m_fullness = value;
            }
        }
    }

    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        m_fullness = 100;
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
        if (other.CompareTag("Food"))
        {
            fullness += 10;
        }
    }
}
