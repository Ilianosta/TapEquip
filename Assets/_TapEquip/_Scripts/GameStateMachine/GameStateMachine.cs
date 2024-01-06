using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : StateManager<GameStateMachine.GameState>
{
    private void Awake()
    {
        States.Add(GameState.menu, new Game_MenuState(GameState.menu));
        States.Add(GameState.game, new Game_GameState(GameState.game));
        States.Add(GameState.end, new Game_EndState(GameState.end));

        CurrentState = States[GameState.menu];
    }

    public void BackToMenu() => ChangeState(GameState.menu);
    // ENUMS
    public enum GameState
    {
        menu,
        game,
        end
    }
}


