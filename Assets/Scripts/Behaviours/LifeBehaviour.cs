using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBehaviour : MonoBehaviour 
{
	public float life;
	public float totalLife;
	// Use this for initialization
	void Start () {
		totalLife = life;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Bullet") 
		{
			life -= col.GetComponent<Weapons.BulletSpacs> ().damage;
			Destroy (col.gameObject);
		}
	}
}
