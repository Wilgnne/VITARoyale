using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Loot;

namespace Weapons.Controllers
{
	
	public class AmmoController : BaseController {

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
		public override bool Append (LootSpecs specs)
		{
			AmmoType type = specs.ammonitionType;
			int amount = specs.amount;

			return true;
		}
	}
}