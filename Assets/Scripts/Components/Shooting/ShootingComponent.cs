using Assets.Scripts.Components.Moving;
using Assets.Scripts.Components.Shooting.Bullets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Components.Shooting
{
	public class ShootingComponent : MonoBehaviour
	{
		[SerializeField]
		private BulletPool weapon;

		// Update is called once per frame
		void Update()
		{
			if (Input.GetButtonDown("Shoot"))
			{
				weapon.GetBullet(transform.position).Shoot(transform.up);
			}
		}
	}
}