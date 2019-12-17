using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Weapons;

namespace Loot
{
	public enum LootType
	{
		Weapon,
		Ammunition
	}

	public class LootSpecs : MonoBehaviour 
	{
		public LootType lootType;
		public AmmoType ammonitionType;
		public GameObject instance;
		public int amount = 1;
	}	
}
