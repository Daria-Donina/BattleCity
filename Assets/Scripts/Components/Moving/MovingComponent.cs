using Assets.Scripts.Components.Moving.StateMachine;
using Assets.Scripts.Components.Moving.StateMachine.States;
using Assets.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Components.Moving
{
	[RequireComponent(typeof(Animator))]
	[RequireComponent(typeof(Rigidbody2D))]
	public class MovingComponent : MonoBehaviour
	{
		[SerializeField]
		private float speed;

		private Animator _animator;
		private Rigidbody2D _rigidbody;
		private MovingController _controller;

		public MovingState State { private get; set; } = GoingUpState.GetInstance();

		private void Awake()
		{
			_animator = GetComponent<Animator>();
			_rigidbody = GetComponent<Rigidbody2D>();
			_controller = GetComponent<MovingController>();
		}

		private void Update()
		{
			State.Update(this, _controller);

			_rigidbody.AddForce(State.Direction * speed, ForceMode2D.Force);

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