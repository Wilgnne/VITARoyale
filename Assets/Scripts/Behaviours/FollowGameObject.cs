using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviours
{
	public class FollowGameObject : MonoBehaviour 
	{
		public string tagToFollow;
		public GameObject objectToFollow;
		public Vector3 targetPosition;

		// Use this for initialization
		void Start () 
		{
			objectToFollow = GameObject.FindWithTag (tagToFollow);
		}

		// Update is called once per frame
		void Update () {
			if (objectToFollow) 
			{
				targetPosition = objectToFollow.transform.position;
				transform.position = new Vector3 (targetPosition.x, targetPosition.y, transform.position.z);
			} 
			else 
			{
				objectToFollow = GameObject.FindWithTag (tagToFollow);
			}
		}
	}	
}