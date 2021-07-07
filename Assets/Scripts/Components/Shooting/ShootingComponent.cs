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

		private MovingComponent _movingComponent;
		private Vector3 _rotation90 = Vector3.forward * 90;

		private void Awake()
		{
			_movingComponent = GetComponent<MovingComponent>();
		}

		// Update is called once per frame
		void Update()
		{
			if (Input.GetButtonDown("Shoot"))
			{
				var bullet = weapon.GetBullet(transform.position);
				var direction = _movingComponent.LookingAt;

				if (direction.x != 0)
				{
					bullet.transform.rotation = Quaternion.Euler(_rotation90);
				}

				bullet.Shoot(direction);
			}
		}
	}
}