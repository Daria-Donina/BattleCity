using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components.Moving.StateMachine.States
{
	/// <summary>
	/// Class implementing standing state.
	/// </summary>
	class StandingState : MovingState
	{
		public override Vector3 Direction { get; protected set; } = Vector3.zero;
		private static StandingState _instance;

		/// <summary>
		/// Get instance of the standing state.
		/// </summary>
		/// <returns> Instance of the standing state. </returns>
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
