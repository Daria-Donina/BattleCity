using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Enemy
{
	[Serializable]
	public class WinningEvent : UnityEvent {}

	public class EnemySpawner : MonoBehaviour
	{
		[SerializeField] public int enemiesAmount { get; private set; } = 18;
		[SerializeField] private int startDelayBetweenSpawn = 3;
		[SerializeField] private int delayBetweenSpawns = 4;
		[SerializeField] private Transform[] spawnPoints;

		private EnemyPool _enemyPool;
		private int _enemiesProduced;
		private int _enemiesRemaining;

		public CounterTextEvent RemainingEnemiesChanged = new CounterTextEvent();
		public WinningEvent GameWon = new WinningEvent();

		private void Awake()
		{
			_enemyPool = FindObjectOfType<EnemyPool>();
			EnemyDamagingComponent.EnemyKilledEvent.AddListener(OnEnemyKilled);
		}

		private void Start()
		{
			InvokeRepeating(nameof(Spawn), startDelayBetweenSpawn, delayBetweenSpawns);
			RemainingEnemiesChanged.Invoke(enemiesAmount);

			_enemiesRemaining = enemiesAmount;
		}

		private void Spawn()
		{
			if (_enemiesProduced >= enemiesAmount)
			{
				return;
			}

			var point = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];

			var enemy = _enemyPool.GetObject(point.position);
			_enemiesProduced++;
		}

		private void OnEnemyKilled()
		{
			_enemiesRemaining--;
			RemainingEnemiesChanged.Invoke(_enemiesRemaining);

			if (_enemiesRemaining == 0)
			{
				GameWon.Invoke();
			}
		}
	}
}
