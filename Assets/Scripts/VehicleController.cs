using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VehicleController : MonoBehaviour
{
    public float acceleration = 10f;

    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        // _rigidbody.AddForce(0, 0, acceleration, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            var force = Vector3.forward * acceleration;
            _rigidbody.AddRelativeForce(force, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            var force = Vector3.back * acceleration;
            _rigidbody.AddRelativeForce(force, ForceMode.Force);
        }
    }
}
