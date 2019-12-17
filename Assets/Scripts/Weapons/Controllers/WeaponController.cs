using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;
using System.Linq;

using Loot;
using Weapons.UI;

namespace Weapons.Controllers
{
	public class WeaponController : MonoBehaviour 
	{
		InputBase input;
		public GameObject weaponGameObject;
		public int weaponsCont = 4;
		public WeaponBase attWeapon;

		public int attWeaponIndex = 0;
		public List<WeaponBase> weapons;

		Animator animator;
		
		bool isFiring = false;

		string[] fires = new string[2]{"fire1", "fire2"};
		int next = 0;

		// Use this for initialization
		void Start () 
		{
			input = GetComponent<InputBase> ();
			animator = GetComponent<Animator> ();

			LoadAttWeapon ();
		}

		// Update is called once per frame
		void Update ()
		{
			if (input.buttonsMap.fire == true && isFiring == false) 
			{
				StartCoroutine ("Fire");
			}

			if (input.buttonsMap.changeWeapon > 0.0f) 
			{
				attWeaponIndex = (attWeaponIndex + 1) % weapons.Count;
			}
			else if (input.buttonsMap.changeWeapon < 0.0f)
			{
				attWeaponIndex = (attWeaponIndex - 1 + weapons.Count) % weapons.Count;
			}
			attWeaponIndex = Mathf.Abs(attWeaponIndex);
			LoadAttWeapon ();
		}

		public bool AddWeapon (LootSpecs specs)
		{
			if (weapons.Count < weaponsCont)
			{
				GameObject instance = Instantiate (specs.instance, transform);
				WeaponBase weapon = instance.GetComponent<WeaponBase> ();
				weapons.Add (weapon);
				weapon.gameObject.SetActive (false);
				WeaponUI.UpdateUI();
				return true;
			}
			return false;
		}

		void LoadAttWeapon()
		{
			attWeapon = weapons [attWeaponIndex];
			attWeapon.gameObject.SetActive (true);
			WeaponUI.SetAttWeapon(attWeaponIndex);
			animator.runtimeAnimatorController = attWeapon.controller;

			foreach (WeaponBase weapon in weapons) 
			{
				if (weapon != attWeapon)
					weapon.gameObject.SetActive (false);
			}
		}

		IEnumerator Fire ()
		{
			isFiring = true;

			animator.SetTrigger (fires [next]);
			next = (next + 1) % fires.Length;

			attWeapon.Fire ();

			yield return new WaitForSeconds (attWeapon.fireRate);
			isFiring = false;
		}
	}
}