using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - target.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var nextPosition = target.transform.position + _offset;
        // nextPosition.y = transform.position.y;
        transform.position = nextPosition;
    }
}
