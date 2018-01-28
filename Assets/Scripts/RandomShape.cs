using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomShape : MonoBehaviour {

    public Sprite[] shapes;
    SpriteRenderer spriteRenderer;
    // Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = shapes[Random.Range(0, shapes.Length)];
	}
	
	

}
