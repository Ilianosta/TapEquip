using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character_Base
{
    [SerializeField] Transform playerSpawnPosition;
    [SerializeField] Transform playerInGamePosition;

    public static System.Action<SkillStatSO> OnSelectSkill;
    protected override void Awake()
    {
        base.Awake();
        OnSelectSkill += skill => SelectedSkill(skill);
    }
    protected override void Start()
    {
        base.Start();
        CreateSkillButtons();
    }
    protected override void CreateCharacter()
    {
        transform.position = playerSpawnPosition.position;
        Vector3 inGamePos = playerInGamePosition.position;
        LeanTween.move(gameObject, inGamePos, 1).setEaseOutBack();
    }

    protected override void Die()
    {
        GameManager.instance.playerWins = false;
        GameManager.instance.GameStateMachine.ChangeState(GameStateMachine.GameState.end);
    }

    protected override void HideCharacter()
    {
        LeanTween.cancel(gameObject);
        transform.position = playerSpawnPosition.position;
    }

    private void CreateSkillButtons()
    {
        foreach (SkillStatSO skill in skills)
        {
            UIManager.instance.CreateSkillButton(skill, this);
        }
    }
    public void SelectedSkill(SkillStatSO skill)
    {
        if (skill == selectedSkill)
        {
            selectedSkill = null;
            return;
        }
        selectedSkill = skill;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) Die();
    }
}
