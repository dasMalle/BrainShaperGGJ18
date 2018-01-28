using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowardsMouse : MonoBehaviour {

    Vector3 mousePosition;
    public float mEyeRadius = 0.1f;
    Vector3 ankerPos;


	// Use this for initialization
	void OnEnable() 
    {
        ankerPos = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        //Vector3.MoveTowards(transform.position, mSwipeController.mSwipePosition, 0.5f);
	}


   
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 lookOffset = (mousePosition - transform.position);

        if (lookOffset.magnitude > mEyeRadius)
            lookOffset = lookOffset.normalized * mEyeRadius;
        //lookOffset.Scale(new Vector3(0.5f, 1.0f));

        transform.position = Vector3.Slerp(transform.position, ankerPos + lookOffset, 0.1f);
    }
}
