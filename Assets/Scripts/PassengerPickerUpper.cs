using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PassengerPickerUpper : MonoBehaviour
{
    private GameObject _passenger;

    public UnityEvent onPassengerPickedUp = new UnityEvent();

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

            onPassengerPickedUp.Invoke();
        }
    }

    public void HandlePassengerDroppedOff()
    {
        Destroy(_passenger);
        _passenger = null;
    }
}
