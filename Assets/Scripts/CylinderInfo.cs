using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CylinderInfo : MonoBehaviour
{
    public float speed;
    public float AngularSpeed;
    protected Rigidbody r;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        speed = r.velocity.magnitude;
        AngularSpeed = r.angularVelocity.magnitude;

        r.AddTorque(Vector3.back);
    }
}
