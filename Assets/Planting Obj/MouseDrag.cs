using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag: MonoBehaviour
{
    public Camera camera;
    public Transform restPosition;

   
    private static Transform currentFillArea; //area to colored
    
    private float offset;

    Vector3 startpos;

    Vector3 touchStartPos;

   
    void Start()
    {
        startpos = transform.position;
        offset= transform.position.z - camera.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase==TouchPhase.Began)
            {
               touchStartPos= GetPosition(touch.position);
            }
            if(touch.phase==TouchPhase.Moved)
            {
                var temp= GetPosition(touch.position);
                var posOffset = Offset(temp);
                transform.position = startpos +posOffset;
            }
        }
    } 
  

    Vector3 GetPosition(Vector2 pos)
    {         
        var worldPos = Camera.main.ScreenToWorldPoint(new Vector3(pos.x,pos.y,offset));
        return worldPos;       
    }

    Vector3 Offset(Vector3 worldPos)
    {
        var x = touchStartPos.x - worldPos.x;
        var y = touchStartPos.y - worldPos.y;
        return new Vector3(-x,-y,0);
    }
   
}
