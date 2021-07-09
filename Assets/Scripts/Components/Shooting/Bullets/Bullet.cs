using Assets.Scripts.Components.Damaging;
using UnityEngine;

namespace Assets.Scripts.Components.Shooting.Bullets
{
	/// <summary>
	/// Class implementing bullet.
	/// </summary>
	[RequireComponent(typeof(Rigidbody2D))]
	[RequireComponent(typeof(Collider2D))]
	public class Bullet : MonoBehaviour
	{
		[SerializeField] private float speed = 10f;
		[SerializeField] private float maxLifetime = 2f;

		private BulletPool _bulletPool;
		private Rigidbody2D _rigidbody;

		private void Awake()
		{
			_bulletPool = FindObjectOfType<BulletPool>();
			_rigidbody = GetComponent<Rigidbody2D>();
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			if (collision.gameObject.TryGetComponent(out DamagingComponent tank))
			{
				tank.OnAttack();
			}

			ReturnToPool();
		}

		/// <summary>
		/// Shoots the bullet in a given direction.
		/// </summary>
		/// <param name="direction"> Direction to shoot bullet in.</param>
		public void Shoot(Vector2 direction)
		{
			transform.SetParent(null);
			_rigidbody.velocity = direction * speed;
			Invoke(nameof(ReturnToPool), maxLifetime);
		}

		private void ReturnToPool()
		{
			_bulletPool.ReturnObject(this);
		}
	}
}
