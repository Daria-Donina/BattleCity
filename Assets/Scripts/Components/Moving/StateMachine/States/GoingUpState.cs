using UnityEngine;

namespace Assets.Scripts.Components.Moving.StateMachine.States
{
	/// <summary>
	/// Class implementing state of going up.
	/// </summary>
	public class GoingUpState : MovingState
	{
		public override Vector3 Direction { get; protected set; } = Vector3.up;
		public override float Rotation { get; protected set; } = 0;
		private static GoingUpState _instance;

		/// <summary>
		/// Get instance of the going up state.
		/// </summary>
		/// <returns> Instance of the going up state. </returns>
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
