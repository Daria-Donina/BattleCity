using Assets.Scripts.Components.Moving.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components.Moving.StateMachine.States
{
	public class GoingUpState : MovingState
	{
		public override Vector3 Direction { get; protected set; } = Vector3.up;
		public override float Rotation { get; protected set; } = 0;
		private static GoingUpState _instance;
		public static GoingUpState GetInstance()
		{
			if (_instance is null)
			{
				_instance = new GoingUpState();
			}

			return _instance;
		}
	}
}
