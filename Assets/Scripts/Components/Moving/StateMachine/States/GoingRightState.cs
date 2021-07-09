using UnityEngine;

namespace Assets.Scripts.Components.Moving.StateMachine.States
{
	/// <summary>
	/// Class implementing state of going right.
	/// </summary>
	public class GoingRightState : MovingState
	{
		public override Vector3 Direction { get; protected set; } = Vector3.right;
		public override float Rotation { get; protected set; } = -90;
		private static GoingRightState _instance;

		/// <summary>
		/// Get instance of the going right state.
		/// </summary>
		/// <returns> Instance of the going right state. </returns>
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
