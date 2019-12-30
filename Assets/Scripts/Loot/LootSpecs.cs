using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Weapons;

namespace Loot
{
	public enum LootController
	{
		AmmoController,
		WeaponController
	}

	public class LootSpecs : MonoBehaviour 
	{
		public LootController lootController;
		public AmmoType ammonitionType;
		public GameObject instance;
		public int amount = 1;
	}	
}
