using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_MenuState : BaseState<GameStateMachine.GameState>
{
    public Game_MenuState(GameStateMachine.GameState key) : base(key)
    {
    }

    public override void EnterState()
    {
        UIManager.instance.ShowMainMenu(true);
    }

    public override void ExitState()
    {
    }

    public override void UpdateState()
    {
        Debug.Log("UPDATING GAME_MENU STATE");
    }

    public override GameStateMachine.GameState GetNextState()
    {
        return GameStateMachine.GameState.game;
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
