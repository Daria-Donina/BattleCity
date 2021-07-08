using Assets.Scripts.Components.Moving;
using Assets.Scripts.Components.Shooting.Bullets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace Assets.Scripts.Components.Shooting
{
	[Serializable]
	public class ShootingEvent : UnityEvent {}

	public class ShootingComponent : MonoBehaviour
	{
		private BulletPool _bulletPool;

		private void Awake()
		{
			_bulletPool = FindObjectOfType<BulletPool>();
		}

		public void Shoot()
		{
			var bullet = _bulletPool.GetObject(transform.position);

			bullet.transform.rotation = transform.rotation;
			bullet.gameObject.layer = gameObject.layer;

			bullet.Shoot(transform.up);
		}
	}
}