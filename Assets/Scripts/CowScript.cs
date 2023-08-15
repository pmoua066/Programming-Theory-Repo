using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowScript : AnimalScript
{
    public override void GetHungry()
    {
        hunger -= 3;
    }
}
