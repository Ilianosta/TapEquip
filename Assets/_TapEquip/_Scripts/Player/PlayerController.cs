using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class PlayerController : Character_Base
{
    [SerializeField] Transform playerSpawnPosition;
    [SerializeField] Transform playerInGamePosition;

    public static System.Action<SkillStatSO> OnSelectSkill;
    public static System.Action OnCastSkill;
    protected override void Awake()
    {
        base.Awake();
        OnSelectSkill += skill => SelectedSkill(skill);
        OnCastSkill += CastSkill;
    }

    protected override void Start()
    {
        base.Start();
        CreateSkillButtons();
    }

    private void CastSkill()
    {
        Debug.Log("CASTING SKILL");
        Character_Base target = UIManager.instance.SelectTarget();
        if (target)
        {
            UseSkill(target);
        }
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
