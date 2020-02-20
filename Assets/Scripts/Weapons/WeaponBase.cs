using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Weapons
{
	[System.Serializable]
	public enum AmmoType
	{
		_9mm
	}
	[System.Serializable]
	public struct UIComponents
	{
		public string name;
		public Sprite image;
	}

	public abstract class WeaponBase : MonoBehaviour 
	{
		public RuntimeAnimatorController controller;
		public GameObject bullet;
		public float ammoCont;
		public AmmoType ammoType;
		public float fireRate = 1f;
		public float damage = 5f;
		public UIComponents UIComponents;

		public virtual bool Fire ()
		{
			if (ammoCont > 0)
			{
				--ammoCont;
				GameObject bulletGO = Instantiate (bullet, transform);
				bulletGO.GetComponent<BulletSpacs> ().damage = damage;
				return true;
			}
			return false;
		}

		public virtual void Reload (int newAmmo)
		{
			ammoCont = newAmmo;
		}
	}
}