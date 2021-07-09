using Assets.Scripts.Components.Moving.StateMachine.States;
using Assets.Scripts.Controllers;
using UnityEngine;

namespace Assets.Scripts.Components.Moving.StateMachine
{
	/// <summary>
	/// Class implementing moving state.
	/// </summary>
	public abstract class MovingState
	{
		private static GoingLeftState _goingLeft = GoingLeftState.GetInstance();
		private static GoingRightState _goingRight = GoingRightState.GetInstance();
		private static GoingUpState _goingUp = GoingUpState.GetInstance();
		private static GoingDownState _goingDown = GoingDownState.GetInstance();
		private static StandingState _standing = StandingState.GetInstance();

		/// <summary>
		/// Direction of the state.
		/// </summary>
		public abstract Vector3 Direction { get; protected set; }

		/// <summary>
		/// Rotation of the state.
		/// </summary>
		public virtual float Rotation { get; protected set; }

		/// <summary>
		/// Updates moving state.
		/// </summary>
		/// <param name="movingComponent"> Component to update state for.</param>
		/// <param name="controller"> Controller to get state from.</param>
		public virtual void Update(MovingComponent movingComponent, MovingController controller)
		{
			if (controller.X == 0 && controller.Y == 0)
			{
				movingComponent.State = _standing;
			}

			if (controller.X > 0)
			{
				movingComponent.State = _goingRight;
			}
			else if (controller.X < 0)
			{
				movingComponent.State = _goingLeft;
			}

			if (controller.Y > 0)
			{
				movingComponent.State = _goingUp;
			}
			else if (controller.Y < 0)
			{
				movingComponent.State = _goingDown;
			}
		}
	}
}
