using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseScipt : AnimalScript
{
    public override void GetHungry()
    {
        hunger -= 2;
    }
}

