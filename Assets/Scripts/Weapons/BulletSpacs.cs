using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
	public class BulletSpacs : MonoBehaviour 
	{
		public float damage;
		public float damageLossPerSecond;
		// Use this for initialization
		void Start () {

		}

		// Update is called once per frame
		void Update () 
		{
			damage -= damageLossPerSecond * Time.deltaTime;
		}
	}
}