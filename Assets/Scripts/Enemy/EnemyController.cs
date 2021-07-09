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
	/// <summary>
	/// Class implementing Enemy moving and shooting logic.
	/// </summary>
	public class EnemyController : MovingController
	{
		/// <summary>
		/// Class storing and controlling direction.
		/// </summary>
		private class Direction
		{
			private static Vector3 _left = Vector3.left;
			private static Vector3 _right = Vector3.right;
			private static Vector3 _up = Vector3.up;
			private static Vector3 _down = Vector3.down;

			private Vector3[] _directions = { _left, _right, _up, _down };

			private int _previousDirectionIndex = -1;

			/// <summary>
			/// Get a direction different from the current one.
			/// </summary>
			/// <returns> A direction vector.</returns>
			public Vector3 GetAnotherDirection()
			{
				var index = Random.Range(0, _directions.Length - 1);

				var direction = _directions[index];

				_previousDirectionIndex = index;
				RearrangeArray();

				return direction;
			}

			private void RearrangeArray()
			{
				Swap(ref _directions[_previousDirectionIndex], 
					ref _directions[_directions.Length - 1]);
			}

			private void Swap(ref Vector3 a, ref Vector3 b)
			{
				var temp = a;
				a = b;
				b = temp;
			}
		}

		public override float X { get; protected set; }
		public override float Y { get; protected set; }
		
		/// <summary>
		/// Event invoking when a shot needs to be fired.
		/// </summary>
		public ShootingEvent FireShot = new ShootingEvent(); 

		private const float DelayForShootingStart = 0.5f;

		[SerializeField] private int minDirectionTime = 1;
		[SerializeField] private int maxDirectionTime = 6;

		[SerializeField] private int shotDelay = 1;

		private Direction _direction;

		private void Awake()
		{
			_direction = new Direction();
		}

		private void OnEnable()
		{
			StartCoroutine(DirectionRoutine());

			StartCoroutine(DelayShootCoroutine());
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			ChangeDirection();
		}

		private IEnumerator DelayShootCoroutine()
		{
			yield return new WaitForSeconds(DelayForShootingStart);

			StartCoroutine(ShootingRoutine());
		}

		private IEnumerator DirectionRoutine()
		{
			while (true)
			{
				ChangeDirection();

				yield return new WaitForSeconds(
					Random.Range(minDirectionTime, maxDirectionTime)
					);
			}
		}

		private IEnumerator ShootingRoutine()
		{
			while (true)
			{
				Shoot();

				yield return new WaitForSeconds(
					shotDelay
					);
			}
		}

		private void ChangeDirection()
		{
			var direction = _direction.GetAnotherDirection();

			X = direction.x;
			Y = direction.y;
		}

		private void Shoot()
		{
			FireShot.Invoke();
		}
	}
}
