using Assets.Scripts.Components.Damaging;
using UnityEngine.Events;

namespace Assets.Scripts.Enemy
{
	/// <summary>
	/// Component that defines enemy behaviour when it's attacked.
	/// </summary>
	public class EnemyDamagingComponent : DamagingComponent
	{
		/// <summary>
		/// Event invoking when the enemy is hit by player's bullet.
		/// </summary>
		public static UnityEvent EnemyKilledEvent = new UnityEvent();

		private EnemyPool _pool;

		private void Awake()
		{
			_pool = FindObjectOfType<EnemyPool>();
		}

		public override void OnAttack()
		{
			_pool.ReturnObject(GetComponent<EnemyController>());
			EnemyKilledEvent.Invoke();
		}
	}
}
