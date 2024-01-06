using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character_Base
{
    protected override void Start()
    {
        base.Start();
        Debug.Log("Enemy attack: " + myStats.attack);
    }
    protected override void CreateCharacter()
    {
        int randomPos = Random.Range(0, GameManager.instance.enemySpawnPositions.Length);
        transform.position = GameManager.instance.enemySpawnPositions[randomPos].position;

        randomPos = Random.Range(0, GameManager.instance.enemyInGamePositions.Length);
        Vector3 inGamePos = GameManager.instance.enemyInGamePositions[randomPos].position;
        LeanTween.move(gameObject, inGamePos, 1).setEaseOutBack();
    }

    protected override void Die()
    {
        throw new System.NotImplementedException();
    }

    protected override void HideCharacter()
    {
        LeanTween.cancel(gameObject);
        int randomPos = Random.Range(0, GameManager.instance.enemySpawnPositions.Length);
        transform.position = GameManager.instance.enemySpawnPositions[randomPos].position;
    }
}
