using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerScript : MonoBehaviour
{
    public float minimum = -0.25f;
    public float maximum = 0.25f;
    private Vector3 offset = new Vector3(0, 0.5f, 2.5f); 

    static float t = 0.0f;
    [SerializeField] private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Interpolate();

        Spin();
    }

    void Interpolate()
    {
        transform.position = new Vector3(0, Mathf.Lerp(minimum, maximum, t), 0) + gameManager.currentPos + offset;

        t += 0.5f * Time.deltaTime;

        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }

    void Spin()
    {
        transform.Rotate(0, 180.0f * Time.deltaTime, 0);
    }
}
