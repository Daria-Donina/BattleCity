using Assets.Scripts.UI;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Enemy
{
	/// <summary>
	/// Class for winning event.
	/// </summary>
	[Serializable]
	public class WinningEvent : UnityEvent {}

	/// <summary>
	/// Class that defines logic of enemy spawning and stores their statistics.
	/// </summary>
	public class EnemySpawner : MonoBehaviour
	{
		[SerializeField] public int enemiesAmount { get; private set; } = 18;
		[SerializeField] private int startDelayBetweenSpawn = 3;
		[SerializeField] private int delayBetweenSpawns = 4;
		[SerializeField] private Transform[] spawnPoints;

		private EnemyPool _enemyPool;
		private int _enemiesProduced;
		private int _enemiesRemaining;

		/// <summary>
		/// Event invoking when amount of remaining enemies to kill has changed.
		/// </summary>
		public CounterTextEvent RemainingEnemiesChanged = new CounterTextEvent();

		/// <summary>
		/// Event invoking when all enemies are killed.
		/// </summary>
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

			_ = _enemyPool.GetObject(point.position);
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
