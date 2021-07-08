using Assets.Scripts.Components.Damaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

namespace Assets.Scripts.Enemy
{
	public class EnemyDamagingComponent : DamagingComponent
	{
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
