using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;
using System.Linq;

using Loot;
using Weapons.UI;

namespace Weapons.Controllers
{
	public class WeaponController : BaseController 
	{
		InputBase input;
		public GameObject weaponGameObject;
		public int maxAmmauntWeapons = 4;
		public WeaponBase attWeapon;

		int attWeaponIndex = 0;
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

		public override bool Append (LootSpecs specs)
		{
			if (weapons.Count < maxAmmauntWeapons)
			{
				GameObject instance = Instantiate (specs.instance, weaponGameObject.transform);
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

		bool ReloadAttWeapon()
		{

			return true;
		}

		IEnumerator Fire ()
		{
			isFiring = true;
			if (attWeapon.Fire ())
			{
				animator.SetTrigger (fires [next]);
				next = (next + 1) % fires.Length;

				yield return new WaitForSeconds (attWeapon.fireRate);
			}

			isFiring = false;
		}
	}
}