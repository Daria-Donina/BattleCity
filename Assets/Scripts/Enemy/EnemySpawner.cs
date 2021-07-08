using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
	public class EnemySpawner : MonoBehaviour
	{
		[SerializeField] private int enemiesAmount = 18;
		[SerializeField] private int startDelayBetweenSpawn = 3;
		[SerializeField] private int delayBetweenSpawns = 4;
		[SerializeField] private Transform[] spawnPoints;

		private EnemyPool _enemyPool;
		private int _enemiesProduced;

		private void Awake()
		{
			_enemyPool = FindObjectOfType<EnemyPool>();
		}

		private void Start()
		{
			InvokeRepeating(nameof(Spawn), startDelayBetweenSpawn, delayBetweenSpawns);
		}

		private void Spawn()
		{
			if (_enemiesProduced >= enemiesAmount)
			{
				return;
			}

			var point = spawnPoints[Random.Range(0, spawnPoints.Length)];

			var enemy = _enemyPool.GetObject(point.position);
			_enemiesProduced++;
		}
	}
}
