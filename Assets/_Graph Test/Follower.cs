using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public bool xFollow, zFollow;
    
    void Start()
    {
        offset = target.position - transform.position;
    }
    
    void Update()
    {
        if(xFollow) 
            transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
        if(zFollow) 
            transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z);
    }
}
