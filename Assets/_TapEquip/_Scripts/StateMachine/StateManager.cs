using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateManager<EState> : MonoBehaviour where EState : Enum
{
    [SerializeField] protected bool autoLoopStates = false;
    protected Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>();
    protected BaseState<EState> CurrentState;

    protected bool isTransitioningState = false;
    void Start()
    {
        CurrentState.EnterState();
    }
    void Update()
    {
        CurrentState.UpdateState();

        if (!autoLoopStates) return;

        EState nextStateKey = CurrentState.GetNextState();
        if (!isTransitioningState && nextStateKey.Equals(CurrentState.StateKey))
        {
            CurrentState.UpdateState();
        }
        else if (!isTransitioningState)
        {
            ChangeState(nextStateKey);
        }
    }
    public BaseState<EState> GetState(EState state)
    {
        BaseState<EState> _state = States[state];
        return _state;
    }
    public void ChangeToNextState()
    {
        EState nextStateKey = CurrentState.GetNextState();
        if (!isTransitioningState)
        {
            ChangeState(nextStateKey);
        }
    }

    public void ChangeState(EState nextStateKey)
    {
        isTransitioningState = true;
        CurrentState.ExitState();
        CurrentState = States[nextStateKey];
        CurrentState.EnterState();
        isTransitioningState = false;
    }

    void OnTriggerEnter(Collider other)
    {
        CurrentState.OnTriggerEnter(other);
    }
    void OnTriggerStay(Collider other)
    {
        CurrentState.OnTriggerStay(other);
    }
    void OnTriggerExit(Collider other)
    {
        CurrentState.OnTriggerExit(other);
    }
}
