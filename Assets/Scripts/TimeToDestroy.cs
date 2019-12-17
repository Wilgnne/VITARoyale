using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToDestroy : MonoBehaviour {
	public float timeToDestroy;

	// Use this for initialization
	void Start () 
	{
		Destroy (gameObject, timeToDestroy);
	}
}
