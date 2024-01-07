using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_GameState : BaseState<GameStateMachine.GameState>
{
    public Game_GameState(GameStateMachine.GameState key) : base(key)
    {
    }

    public override void EnterState()
    {
        GameManager.SpawnCharacters?.Invoke(true);
        UIManager.instance.ShowInGameUI(true);
    }

    public override void ExitState()
    {
        GameManager.SpawnCharacters?.Invoke(false);
    }

    public override void UpdateState()
    {
        Debug.Log("UPDATING GAME_GAME STATE");
    }

    public override GameStateMachine.GameState GetNextState()
    {
        return GameStateMachine.GameState.end;
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
