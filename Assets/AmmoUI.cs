using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Weapons.Controllers;

public class AmmoUI : MonoBehaviour {
	public AmmoController controller;
	public AmmoPanel ammoPanel1;

	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag("Player").GetComponent<AmmoController>();
	}
	
	// Update is called once per frame
	void Update () {
		ammoPanel1.SetText(controller.ammoAmount[Weapons.AmmoType._9mm].ToString());
		
	}
}
