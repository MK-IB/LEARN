using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    
    void Start()
    {
        offset = target.position - transform.position;
    }
    
    void Update()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }
}
