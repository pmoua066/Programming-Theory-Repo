using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Vector3[] foodPoints;
    public Vector3 currentPos;
    private int indexHolder;
    public GameObject[] fruitArray;
    private int fruitIndex;
    public GameObject[] fruitSpawn;
    private bool foodCooldown;
    private CowScript cowScript;
    private HorseScipt horseScript;
    private StagScript stagScript;
    //public bool isGameActive { get; private set; }

    [SerializeField] private TextMeshProUGUI cowFullness;
    [SerializeField] private TextMeshProUGUI hourseFullness;
    [SerializeField] private TextMeshProUGUI stagFullness;

    void Start()
    {
        //isGameActive = true;
        foodCooldown = false;
        indexHolder = 1; //sets the position to center
        fruitIndex = 1; //sets the fruit to carrot
        currentPos = foodPoints[indexHolder]; //sets the initial pos

        cowScript = GameObject.Find("Animal_Cow").GetComponent<CowScript>();
        horseScript = GameObject.Find("Animal_Horse").GetComponent<HorseScipt>();
        stagScript = GameObject.Find("Animal_Stag").GetComponent<StagScript>();
    }

    void Update()
    {
        controlMovement();

        fruitSelector();

        SpawnFruit();

        displayFullness();
    }
    void displayFullness()
    {
        cowFullness.text = "" + cowScript.fullness;
        hourseFullness.text = "" + horseScript.fullness;
        stagFullness.text = "" + stagScript.fullness;
    }
    void controlMovement()
    {
        fruitArray[0].transform.position = currentPos;
        fruitArray[1].transform.position = currentPos;
        fruitArray[2].transform.position = currentPos;

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

    void fruitSelector()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (fruitIndex == 1)
            {
                fruitIndex++;
                fruitArray[1].SetActive(false);
                fruitArray[2].SetActive(true);
            }
            if (fruitIndex == 0)
            {
                fruitIndex++;
                fruitArray[0].SetActive(false);
                fruitArray[1].SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (fruitIndex == 1)
            {
                fruitIndex--;
                fruitArray[1].SetActive(false);
                fruitArray[0].SetActive(true);
            }
            if (fruitIndex == 2)
            {
                fruitIndex--;
                fruitArray[2].SetActive(false);
                fruitArray[1].SetActive(true);
            }
        }
    }

    void SpawnFruit()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !foodCooldown)
        {
            Instantiate(fruitSpawn[fruitIndex], currentPos, fruitSpawn[fruitIndex].transform.rotation);
            StartCoroutine(foodReset());
        }
    }

    IEnumerator foodReset()
    {
        foodCooldown = true;
        yield return new WaitForSeconds(1);
        foodCooldown = false;
    }
}
