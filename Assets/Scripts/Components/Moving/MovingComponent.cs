using Assets.Scripts.Components.Moving.StateMachine;
using Assets.Scripts.Components.Moving.StateMachine.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Components.Moving
{
	[RequireComponent(typeof(Animator))]
	public class MovingComponent : MonoBehaviour
	{
		[SerializeField]
		private float speed;

		private Animator _animator;
		public MovingState State { private get; set; } = GoingUpState.GetInstance();
		public Vector3 LookingAt { get; private set; }

		private void Awake()
		{
			_animator = GetComponent<Animator>();

			LookingAt = State.Direction;
		}

		private void Update()
		{
			State.Update(this);

			transform.Translate(State.Direction * speed * Time.deltaTime);

			if (State.AnimatorState == 0)
			{
				_animator.enabled = false;
			}
			else
			{
				LookingAt = State.Direction;

				_animator.enabled = true;
				_animator.SetInteger("State", State.AnimatorState);
			}
		}
	}
}