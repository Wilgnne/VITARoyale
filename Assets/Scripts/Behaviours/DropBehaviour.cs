using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LifeBehaviour))]
public class DropBehaviour : MonoBehaviour {

	LifeBehaviour lb;

	public List<GameObject> drops;

	// Use this for initialization
	void Start () 
	{
		lb = GetComponent<LifeBehaviour> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (lb.life < 0)
			Drop ();
		
		float halfLife = 0.5f * (lb.life / lb.totalLife) + 0.5f;
		transform.localScale = new Vector3 (halfLife, halfLife, halfLife);

	}

	public void Drop()
	{
		foreach (GameObject drop in drops) 
		{
			Vector3 randPos = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0);
			Instantiate (drop, transform.position + randPos, Quaternion.identity);
		}
		Destroy (gameObject);
	}
}
