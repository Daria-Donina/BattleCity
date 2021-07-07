﻿using Assets.Scripts.Components.Moving.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components.Moving.StateMachine.States
{
	public class GoingRightState : MovingState
	{
		public override Vector3 Direction { get; protected set; } = Vector3.right;
		public override int AnimatorState { get; protected set; } = 2;
		private static GoingRightState _instance;
		public static GoingRightState GetInstance()
		{
			if (_instance is null)
			{
				_instance = new GoingRightState();
			}

			return _instance;
		}
	}
}