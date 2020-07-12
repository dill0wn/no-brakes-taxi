using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestinationController : MonoBehaviour
{
    public float dropOffTime = 0.5f;

    public UnityEvent onDroppedOff = new UnityEvent();

    private Collider _target;
    private float _timer;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "Destination")
        {
            return;
        }
        if (_target != null)
        {
            return;
        }

        _target = collider;

        _timer = 0f;
    }

    // called once per PHYSICS update
    public void OnTriggerStay(Collider collider)
    {
        if (collider.tag != "Destination")
        {
            return;
        }

        if (_target != null && collider != _target)
        {
            return;
        }

        _timer += Time.fixedDeltaTime;

        if (_timer > dropOffTime)
        {
            Debug.Log("Dropped Off");
            onDroppedOff.Invoke();
        }
        else
        {
            Debug.LogFormat("Dropping Off... {0}", (_timer / dropOffTime));
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.tag != "Destination")
        {
            return;
        }

        if (_target != null && collider != _target)
        {
            return;
        }

        _timer = 0f;
        _target = null;
    }
}
