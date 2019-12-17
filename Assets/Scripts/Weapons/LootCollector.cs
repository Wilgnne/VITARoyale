using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;

using Loot;
using Weapons.Controllers;

namespace Weapons
{
	[RequireComponent(typeof(WeaponController))]
	[RequireComponent(typeof(AmmoController))]
	[RequireComponent(typeof(InputSelector))]
	public class LootCollector : MonoBehaviour 
	{
		WeaponController weaponController;
		AmmoController ammoController;
		InputBase input;

		// Use this for initialization
		void Start ()
		{
			weaponController = GetComponent<WeaponController> ();
			ammoController = GetComponent<AmmoController> ();
			input = GetComponent<InputBase> ();
		}

		void OnTriggerStay2D(Collider2D col)
		{
			if (input.buttonsMap.collect)
			{
				LootSpecs specs = col.GetComponent<LootSpecs> ();
				if (col.tag == "WeaponItem") 
				{

					if (weaponController.AddWeapon (specs))
						Destroy (col.gameObject);
				}
				else if (col.tag == "AmmunitionItem")
				{
					ammoController.AppendAmmo(specs.ammonitionType, specs.amount);
				}
			}
		}
	}
}