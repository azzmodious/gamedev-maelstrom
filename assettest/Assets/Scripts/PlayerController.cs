using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed;
    public float thrusterPower;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float dir = Input.GetAxis("Horizontal");
        float thrust = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.up, dir * Time.deltaTime * turnSpeed);
        rb.AddForce(transform.forward * thrusterPower * thrust );

    }
}
