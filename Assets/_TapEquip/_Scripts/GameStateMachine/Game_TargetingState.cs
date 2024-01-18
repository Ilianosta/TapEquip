using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_TargetingState : BaseState<GameStateMachine.GameState>
{
    public Game_TargetingState(GameStateMachine.GameState key) : base(key)
    {
    }

    public override void EnterState()
    {
        UIManager.instance.ShowTargetingScreen(true);
    }

    public override void ExitState()
    {
    }

    public override GameStateMachine.GameState GetNextState()
    {
        return GameStateMachine.GameState.game;
    }

    public override void UpdateState()
    {

    }

    public override void OnTriggerEnter(Collider other)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerExit(Collider other)
    {
        throw new System.NotImplementedException();
    }

    public override void OnTriggerStay(Collider other)
    {
        throw new System.NotImplementedException();
    }

}
