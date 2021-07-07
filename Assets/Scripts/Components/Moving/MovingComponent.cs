using Assets.Scripts.Components.Moving.StateMachine;
using Assets.Scripts.Components.Moving.StateMachine.States;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MovingComponent : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Animator _animator;
    public MovingState State { private get; set; } = GoingUpState.GetInstance();

    private void Awake()
    {
        _animator = GetComponent<Animator>();
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
            _animator.enabled = true;
            _animator.SetInteger("State", State.AnimatorState);
        }
    }
}
