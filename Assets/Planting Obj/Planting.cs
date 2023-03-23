using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planting : MonoBehaviour
{
    private Transform _spherePoint;
    private LineRenderer _line;
    
    void Start()
    {
        _spherePoint = transform.GetChild(0);
        _line = GetComponent<LineRenderer>();
        _line.SetPosition(0, transform.position);
    }
    
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 5))
        {
            _line.SetPosition(0, transform.position);
            _line.SetPosition(1, hit.point);
            _spherePoint.transform.position = hit.point;
        }

    }
}
