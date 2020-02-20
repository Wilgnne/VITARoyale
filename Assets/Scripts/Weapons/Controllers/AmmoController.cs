using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

using Loot;

namespace Weapons.Controllers
{
	
	public class AmmoController : BaseController {

		public Dictionary<AmmoType, int> ammoAmount;

		// Use this for initialization
		void Start () {
			ammoAmount = Enum.GetValues(typeof(AmmoType))
               .Cast<AmmoType>()
               .ToDictionary(t => t, t => 0 );
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		public override bool Append (LootSpecs specs)
		{
			AmmoType type = specs.ammonitionType;
			int amount = specs.amount;

			ammoAmount[type] += amount;

			return true;
		}
	}
}