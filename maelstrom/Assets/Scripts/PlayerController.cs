using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed;
    public float thrustStrength; 
    private Rigidbody rb; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime * rotation);

        float thrustInput = Input.GetAxis("Vertical");
        rb.AddForce(transform.forward * thrustStrength * thrustInput * Time.deltaTime);
    }

    private void FixedUpdate()
    {
       
    }
}
