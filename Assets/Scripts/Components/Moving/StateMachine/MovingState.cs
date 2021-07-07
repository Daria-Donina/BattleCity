using Assets.Scripts.Components.Moving.StateMachine.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Components.Moving.StateMachine
{
	public abstract class MovingState
	{
		private static GoingLeftState _goingLeft = GoingLeftState.GetInstance();
		private static GoingRightState _goingRight = GoingRightState.GetInstance();
		private static GoingUpState _goingUp = GoingUpState.GetInstance();
		private static GoingDownState _goingDown = GoingDownState.GetInstance();
		private static StandingState _standing = StandingState.GetInstance();

		public virtual Vector3 Direction { get; protected set; }
		public virtual float Rotation { get; protected set; }

		public virtual int AnimatorState { get; protected set; }

		public virtual void Update(MovingComponent movingComponent)
		{
			if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
			{
				movingComponent.State = _standing;
			}

			if (Input.GetAxisRaw("Horizontal") > 0)
			{
				movingComponent.State = _goingRight;
			}
			else if (Input.GetAxisRaw("Horizontal") < 0)
			{
				movingComponent.State = _goingLeft;
			}

			if (Input.GetAxisRaw("Vertical") > 0)
			{
				movingComponent.State = _goingUp;
			}
			else if (Input.GetAxisRaw("Vertical") < 0)
			{
				movingComponent.State = _goingDown;
			}
		}
	}
}
