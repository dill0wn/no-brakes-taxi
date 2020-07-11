﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var nextPosition = target.transform.position;
        nextPosition.y = transform.position.y;
        transform.position = nextPosition;
    }
}
