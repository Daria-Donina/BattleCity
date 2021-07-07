using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components.Moving.StateMachine.States
{
	class StandingState : MovingState
	{
		public override Vector3 Direction { get; protected set; } = Vector3.zero;
		public override int AnimatorState { get; protected set; } = 0;
		private static StandingState _instance;
		public static StandingState GetInstance()
		{
			if (_instance is null)
			{
				_instance = new StandingState();
			}

			return _instance;
		}
	}
}
