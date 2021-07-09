using UnityEngine;

namespace Assets.Scripts.Components.Moving.StateMachine.States
{
	/// <summary>
	/// Class implementing state of going left.
	/// </summary>
	public class GoingLeftState : MovingState
	{
		public override Vector3 Direction { get; protected set; } = Vector3.left;
		public override float Rotation { get; protected set; } = 90;

		private static GoingLeftState _instance;

		/// <summary>
		/// Get instance of the going left state.
		/// </summary>
		/// <returns> Instance of the going left state. </returns>
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
