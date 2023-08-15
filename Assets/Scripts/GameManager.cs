using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Vector3[] foodPoints;
    public Vector3 currentPos;
    private int indexHolder;
    private bool foodCooldown;
    // Start is called before the first frame update
    void Start()
    {
        foodCooldown = false;
        indexHolder = 1;
        currentPos = foodPoints[indexHolder];
    }

    // Update is called once per frame
    void Update()
    {
        controlMovement();


    }

    void controlMovement()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (indexHolder > 0)
            {
                indexHolder--;
                currentPos = foodPoints[indexHolder];
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (indexHolder < 2)
            {
                indexHolder++;
                currentPos = foodPoints[indexHolder];
            }
        }
    }
}
