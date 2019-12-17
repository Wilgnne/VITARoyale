using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputs
{
	public class ControllerInput : InputBase 
	{
		public void Update ()
		{
			UpdateAxiFromAxis (_namePrimaryAxi, ref primaryAxi);
			UpdateAxiFromAxis (_nameSecundaryAxi, ref secundaryAxi);

			buttonsMap.fire = Input.GetButton (_nameButtonsMap.fire);
			buttonsMap.changeWeapon = Input.GetAxisRaw (_nameButtonsMap.changeWeapon);
			buttonsMap.collect = Input.GetButton (_nameButtonsMap.collect);
		}
	}	
}