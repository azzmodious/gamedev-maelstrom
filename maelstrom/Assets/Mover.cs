using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;
    public float tumble;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;
        //rb.velocity = transform.forward * speed;
        rb.velocity = Random.insideUnitSphere * speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
