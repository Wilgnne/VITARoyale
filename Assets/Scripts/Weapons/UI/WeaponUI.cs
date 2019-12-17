using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Weapons.Controllers;

namespace Weapons.UI
{
	public class WeaponUI : MonoBehaviour 
	{
		public static WeaponUI weaponUI;
		public WeaponController controller;
		public Color active, inative;
		public List<WeaponSlot> slots;

		void Awake ()
		{
			if (weaponUI == null)
				weaponUI = this;
		}

		// Use this for initialization
		void Start () 
		{
			controller = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponController>();
			UpdateUI();
		}

		public static void UpdateUI ()
		{
			for (int i = 0; i < weaponUI.controller.weapons.Count; i++)
			{
				WeaponBase weapon = weaponUI.controller.weapons[i];
				WeaponSlot slot = weaponUI.slots[i];

				slot.nameText.text = weapon.UIComponents.name;
				slot.iconImage.sprite = weapon.UIComponents.image;
			}
		}

		public static void SetAttWeapon(int i)
		{
			if (i < weaponUI.slots.Count)
			{
				foreach (WeaponSlot slot in weaponUI.slots)
				{
					slot.panel.color = weaponUI.inative;
				}

				weaponUI.slots[i].panel.color = weaponUI.active;
			}
		}
	}
}