using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Forward : MonoBehaviour {
	Rigidbody2D rb;
	public float speed = 100f;
	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		rb.velocity = transform.up.normalized * speed;
	}
}
