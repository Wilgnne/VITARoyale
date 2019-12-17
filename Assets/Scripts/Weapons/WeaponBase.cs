using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Weapons
{
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
		public AmmoType ammoType;
		public float fireRate = 1f;
		public float damage = 5f;
		public UIComponents UIComponents;

		public virtual void Fire ()
		{
			GameObject bulletGO = Instantiate (bullet, transform);
			bulletGO.GetComponent<BulletSpacs> ().damage = damage;
		}
	}
}