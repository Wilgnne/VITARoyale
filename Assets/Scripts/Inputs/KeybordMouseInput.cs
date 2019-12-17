using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputs
{
	public class KeybordMouseInput : InputBase 
	{
		void Update ()
		{
			UpdateAxiFromAxis (_namePrimaryAxi, ref primaryAxi);
			UpdateAxiFromMousePosition (ref secundaryAxi);

			buttonsMap.fire = Input.GetButton (_nameButtonsMap.fire);
			buttonsMap.changeWeapon = Input.GetAxisRaw (_nameButtonsMap.changeWeapon);
			buttonsMap.collect = Input.GetButton (_nameButtonsMap.collect);
		}

		void UpdateAxiFromMousePosition (ref Vector2 axi)
		{
			Vector2 max = new Vector2 (Screen.width, Screen.height);
			Vector2 half = max / 2;

			Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

			//mousePos = 2 * mousePos - Vector2.one;

			Vector2 dir = mousePos - half;
			float ang = Vector2.SignedAngle(Vector2.right, dir);
			//axi.Set (mousePos.x, mousePos.y);
			axi.Set (Mathf.Cos(Mathf.Deg2Rad*ang), Mathf.Sin(Mathf.Deg2Rad*ang));
		}
	}
}