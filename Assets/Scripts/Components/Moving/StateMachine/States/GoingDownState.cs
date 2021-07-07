using Assets.Scripts.Components.Moving.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components.Moving.StateMachine.States
{
	public class GoingDownState : MovingState
	{
		public override Vector3 Direction { get; protected set; } = Vector3.down;
		public override int AnimatorState { get; protected set; } = 4;

		private static GoingDownState _instance;

		public static GoingDownState GetInstance()
		{
			if (_instance is null)
			{
				_instance = new GoingDownState();
			}

			return _instance;
		}
	}
}
