using Assets.Scripts.Components.Moving.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components.Moving.StateMachine.States
{
	public class GoingLeftState : MovingState
	{
		public override Vector3 Direction { get; protected set; } = Vector3.left;
		public override float Rotation { get; protected set; } = 90;

		private static GoingLeftState _instance;
		public static GoingLeftState GetInstance()
		{
			if (_instance is null)
			{
				_instance = new GoingLeftState();
			}

			return _instance;
		}
	}
}
