using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform[] enemySpawnPositions;
    public Transform[] enemyInGamePositions;
    public GameStateMachine GameStateMachine => gameStateMachine;
    private GameStateMachine gameStateMachine;

    public static System.Action<bool> SpawnCharacters;
    internal bool playerWins;

    private void Awake()
    {
        if (GameManager.instance) Destroy(this);
        else GameManager.instance = this;

        gameStateMachine = GetComponent<GameStateMachine>();
    }
}
