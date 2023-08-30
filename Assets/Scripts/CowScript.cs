using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowScript : AnimalScript //INHERITENCE
{
    public override void GetHungry() //Polymorphism
    {
        fullness -= 3; 
    }
}
