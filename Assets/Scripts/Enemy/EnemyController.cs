using Assets.Scripts.Components.Shooting;
using Assets.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
	public class EnemyController : MovingController
	{
		public override float X { get; protected set; }
		public override float Y { get; protected set; }

		[SerializeField] private int minDirectionTime = 1;
		[SerializeField] private int maxDirectionTime = 6;

		[SerializeField] private int shotDelay;

		public ShootingEvent FireShot = new ShootingEvent(); 

		private int[] _coordinates = new int[4] { -1, 1, 0, 0 };
		private IEnumerator _movingRoutine;
		private IEnumerator _shootingRoutine;

		private const float DelayForShootingStart = 0.5f;

		private void Awake()
		{
			_movingRoutine = DirectionRoutine();
			_shootingRoutine = ShootingRoutine();
		}

		private void OnEnable()
		{
			StartCoroutine(_movingRoutine);

			StartCoroutine(DelayShootCoroutine());
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			ChangeDirection();
		}

		private IEnumerator DelayShootCoroutine()
		{
			yield return new WaitForSeconds(DelayForShootingStart);

			StartCoroutine(_shootingRoutine);
		}

		private IEnumerator DirectionRoutine()
		{
			while (true)
			{
				yield return new WaitForSeconds(
					Random.Range(minDirectionTime, maxDirectionTime)
					);

				ChangeDirection();
			}
		}

		private IEnumerator ShootingRoutine()
		{
			while (true)
			{
				yield return new WaitForSeconds(
					shotDelay
					);

				Shoot();
			}
		}

		private void ChangeDirection()
		{
			X = _coordinates[Random.Range(0, _coordinates.Length)];

			if (X == 0)
			{
				Y = _coordinates[Random.Range(0, _coordinates.Length - 2)];
			}
			else
			{
				Y = 0;
			}
		}

		private void Shoot()
		{
			FireShot.Invoke();
		}
	}
}
