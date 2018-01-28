using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class MousePositionMover : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
}
