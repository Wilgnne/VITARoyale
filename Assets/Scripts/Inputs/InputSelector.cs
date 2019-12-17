using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputs
{
	public enum Inputs
	{
		KeybordMouse,
		Controller,
	}

	[System.Serializable]
	public struct SInput
	{
		public NameAxi primaryAxi, secundaryAxi;
		public NameButtonsMap buttonsMap;
	}

	public class InputSelector : MonoBehaviour 
	{
		public Inputs selectedInput;

		public SInput config;

		public InputBase inUse;

		void Awake ()
		{
			if (selectedInput == Inputs.Controller) 
			{
				inUse = gameObject.AddComponent<ControllerInput> () as InputBase;
			} 
			else if (selectedInput == Inputs.KeybordMouse) 
			{
				inUse = gameObject.AddComponent<KeybordMouseInput> () as InputBase;
			}

			//inUse.fire = config.fire;
			inUse.SetPrimaryAxi(config.primaryAxi);

			inUse.SetSecundaryAxi(config.secundaryAxi);
			inUse.SetButtonsMap (config.buttonsMap);
		}
	}
}