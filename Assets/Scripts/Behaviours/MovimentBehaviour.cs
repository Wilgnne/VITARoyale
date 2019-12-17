using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;

namespace Behaviours
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class MovimentBehaviour : MonoBehaviour 
	{
		Rigidbody2D rb;
		public InputBase input;

		public float velocity = 10.0f;

		// Use this for initialization
		void Start () 
		{
			rb = GetComponent<Rigidbody2D> ();
			input = GetComponent<InputBase> ();
		}

		// Update is called once per frame
		void Update () 
		{
			rb.velocity = input.primaryAxi * velocity;
		}
	}
}