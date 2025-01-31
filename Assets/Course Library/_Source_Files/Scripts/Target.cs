using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    Rigidbody targetRb; 
    // Start is called before the first frame update
    void Start()
    {
        targetRb=GetComponent<Rigidbody>();
        targetRb.AddForce(Vector3.up * Random.Range(12,16), ForceMode.Impulse);
        targetRb.AddTorque(Random.Range(-10,20), Random.Range(-10,20), Random.Range(-10,20),ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
