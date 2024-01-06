using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_EndState : BaseState<GameStateMachine.GameState>
{
    private float timeToBack = 3;
    private float counter;
    public Game_EndState(GameStateMachine.GameState key) : base(key)
    {
    }

    public override void EnterState()
    {
        UIManager.instance.ShowEndUI(true);
        counter = timeToBack;
    }

    public override void ExitState()
    {
        UIManager.instance.ShowEndUI(false);
    }
    public override void UpdateState()
    {
        counter -= Time.deltaTime;
        if (counter < 0) GameManager.instance.GameStateMachine.ChangeToNextState();
    }
    public override GameStateMachine.GameState GetNextState()
    {
        return GameStateMachine.GameState.menu;
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
