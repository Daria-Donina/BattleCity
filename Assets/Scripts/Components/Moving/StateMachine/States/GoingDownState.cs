using UnityEngine;

namespace Assets.Scripts.Components.Moving.StateMachine.States
{
	/// <summary>
	/// Class implementing state of going down.
	/// </summary>
	public class GoingDownState : MovingState
	{
		public override Vector3 Direction { get; protected set; } = Vector3.down;
		public override float Rotation { get; protected set; } = 180;

		private static GoingDownState _instance;

		/// <summary>
		/// Get instance of the going down state.
		/// </summary>
		/// <returns> Instance of the going down state. </returns>
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
