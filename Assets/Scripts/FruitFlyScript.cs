using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitFlyScript : MonoBehaviour
{
    private Rigidbody fruitRB;
    private Vector3 flyDirection;
    // Start is called before the first frame update
    void Start()
    {
        fruitRB = gameObject.GetComponent<Rigidbody>();
        flyDirection = new Vector3(0, 1000, 500);
        fruitRB.AddForce(flyDirection * Time.deltaTime, ForceMode.Impulse);
        StartCoroutine(debugDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator debugDestroy()
    {
        Debug.Log("destroy started");
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered");
        Destroy(gameObject);
    }
}
