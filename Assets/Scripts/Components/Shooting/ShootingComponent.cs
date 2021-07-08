using Assets.Scripts.Components.Moving;
using Assets.Scripts.Components.Shooting.Bullets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Components.Shooting
{
	public class ShootingComponent : MonoBehaviour
	{
		private BulletPool _bulletPool;

		private void Awake()
		{
			_bulletPool = FindObjectOfType<BulletPool>();
		}

		public void Shoot()
		{
			var bullet = _bulletPool.GetBullet(transform.position);

			bullet.transform.rotation = transform.rotation;

			bullet.Shoot(transform.up);
		}
	}
}