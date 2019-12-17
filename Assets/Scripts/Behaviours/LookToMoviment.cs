using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;

namespace Behaviours
{
	public class LookToMoviment : MonoBehaviour 
	{
		InputBase input;
		Vector2 lookTo;
		float forwardAngle = 0;
		float lookLimit = 0.0f;

		// Use this for initialization
		void Start () 
		{
			input = GetComponent<InputBase> ();
		}

		// Update is called once per frame
		void Update () 
		{
			lookTo = input.secundaryAxi;
			if (lookTo == Vector2.zero) 
			{
				lookTo = input.primaryAxi;	
			}
			
			if (lookTo.magnitude > lookLimit || lookTo.magnitude < -lookLimit)
			{
				forwardAngle = Vector2.SignedAngle (Vector2.up, lookTo);
			}

			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, forwardAngle);
			forwardAngle += 90;
			Debug.DrawLine(transform.position, transform.position + ((Vector3.right*Mathf.Cos(Mathf.Deg2Rad*forwardAngle) + (Vector3.up*Mathf.Sin(Mathf.Deg2Rad*forwardAngle))))*3);
		}
	}
}