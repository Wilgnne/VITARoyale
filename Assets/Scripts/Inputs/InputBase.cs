using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputs
{
	[Serializable]
	public class NameAxi
	{
		public string horizontal = "Horizontal";
		public string vertical = "Vertical";

		public NameAxi (string _horizontal, string _vertical)
		{
			horizontal = _horizontal;
			vertical   = _vertical;
		}

		public NameAxi () {}
	}

	[Serializable]
	public class NameButtonsMap
	{
		public string fire;
		public string changeWeapon;
		public string collect;
	}

	[Serializable]
	public class ValueButtonsMap
	{
		public bool fire;
		public float changeWeapon;
		public bool collect;
	}

	public class InputBase : MonoBehaviour
	{
		protected NameAxi _namePrimaryAxi;
		protected NameAxi _nameSecundaryAxi;
		protected NameButtonsMap _nameButtonsMap;

		public Vector2 primaryAxi = new Vector2();
		public Vector2 secundaryAxi = new Vector2();

		public ValueButtonsMap buttonsMap = new ValueButtonsMap();

		protected void UpdateAxiFromAxis (NameAxi _axi, ref Vector2 axi)
		{
			axi.Set(Input.GetAxis (_axi.horizontal), Input.GetAxis (_axi.vertical));
		}

		public void SetPrimaryAxi (NameAxi _axi)
		{
			_namePrimaryAxi = _axi;
		}

		public void SetSecundaryAxi (NameAxi _axi)
		{
			_nameSecundaryAxi = _axi;
		}

		public void SetButtonsMap (NameButtonsMap _buttonsMap)
		{
			_nameButtonsMap = _buttonsMap;
		}
	}
}