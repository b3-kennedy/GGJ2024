using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeryHeavy : MonoBehaviour
{

    float oldWeight;

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Rigidbody2D>())
        {
            oldWeight = GetComponent<Rigidbody2D>().mass;
            GetComponent<Rigidbody2D>().mass = oldWeight * 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
