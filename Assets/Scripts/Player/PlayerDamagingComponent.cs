using Assets.Scripts.Components.Damaging;
using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Player
{
	[Serializable]
	public class GameOverEvent : UnityEvent {}

	public class PlayerDamagingComponent : DamagingComponent
	{
		[SerializeField] private int livesAmount = 3;
		
		private Vector3 _respawnPoint;
		public GameOverEvent GameOverEvent = new GameOverEvent();
		public CounterTextEvent LivesNumberChanged = new CounterTextEvent();

		private void Awake()
		{
			_respawnPoint = transform.position;
		}

		private void Start()
		{
			LivesNumberChanged.Invoke(livesAmount);
		}

		public override void OnAttack()
		{
			livesAmount--;
			LivesNumberChanged.Invoke(livesAmount);

			if (livesAmount == 0)
			{
				GameOverEvent.Invoke();
				return;
			}

			transform.position = _respawnPoint;
		}
	}
}
