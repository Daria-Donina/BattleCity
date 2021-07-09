using Assets.Scripts.Components.Moving.StateMachine;
using Assets.Scripts.Components.Moving.StateMachine.States;
using Assets.Scripts.Controllers;
using UnityEngine;

namespace Assets.Scripts.Components.Moving
{
	/// <summary>
	/// Component that allows character to move.
	/// </summary>
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(Rigidbody2D))]
	public class MovingComponent : MonoBehaviour
	{
		/// <summary>
		/// Character moving state.
		/// </summary>
		public MovingState State { private get; set; } = GoingUpState.GetInstance();

		[SerializeField]
		private float speed;

		private Animator _animator;
		private Rigidbody2D _rigidbody;
		private MovingController _controller;

		private void Awake()
		{
			_animator = GetComponent<Animator>();
			_rigidbody = GetComponent<Rigidbody2D>();
			_controller = GetComponent<MovingController>();
		}

		private void Update()
		{
			State.Update(this, _controller);

			_rigidbody.AddForce(State.Direction * speed * Time.deltaTime, ForceMode2D.Force);

			if (State == StandingState.GetInstance())
			{
				_animator.speed = 0;
			}
			else
			{
				_rigidbody.MoveRotation(State.Rotation);

				_animator.speed = 1;
			}
		}
	}
}