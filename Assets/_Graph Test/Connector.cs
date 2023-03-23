using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : MonoBehaviour
{
    public Transform point1, point2;

    private LineRenderer _line;

    private void Start()
    {
        _line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        _line.SetPosition(0, point1.position);
        _line.SetPosition(1, point2.position);
    }
}
