using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerController : MonoBehaviour
{
    private GameObject _passenger;

    void OnCollisionEnter(Collision collision)
    {
        if (_passenger != null)
        {
            return;
        }

        if (collision.gameObject.tag == "Passenger")
        {
            _passenger = collision.gameObject;
            _passenger.SetActive(false);
            Debug.LogFormat("Picked up {0}", _passenger);
        }
    }
}
