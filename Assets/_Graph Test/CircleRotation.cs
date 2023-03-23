using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotation : MonoBehaviour
{
    public Transform pivotPoint;
    public float rotationSpeed = 50f;
    public float radius = 5f;

    void Update()
    {
        transform.RotateAround(pivotPoint.position, Vector3.up, rotationSpeed * Time.deltaTime);
        //transform.position = pivotPoint.position + (transform.position - pivotPoint.position).normalized * radius;
    }
}
