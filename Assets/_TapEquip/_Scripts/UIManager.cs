using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Player Skills")]
    [SerializeField] private GameObject skillPrefabGo;
    [SerializeField] private Transform skillParent;

    [Header("References")]
    [SerializeField] private GameObject mainMenuObj;
    [SerializeField] private GameObject inGameObj;
    [SerializeField] private UIEndScreen endScreen;
    [SerializeField] private UITargetingScreen targetingScreen;
    [SerializeField] private UIShopScreen shopScreen;
    public UIShopScreen ShopScreen => shopScreen;
    public static System.Action<SkillStatSO> OnSendindSkill;
    private void Awake()
    {
        if (UIManager.instance) Destroy(this);
        else UIManager.instance = this;

        OnSendindSkill += skill => SelectTarget(skill);
    }
    private void Start()
    {
        HideAllScreens();
    }

    internal void HideAllScreens()
    {
        ShowMainMenu(false);
        ShowInGameUI(false);
        ShowEndUI(false);
        ShowTargetingScreen(false);
        ShowShopScreen(false);
    }

    internal void ShowMainMenu(bool show)
    {
        mainMenuObj.SetActive(show);
    }

    internal void ShowInGameUI(bool show)
    {
        inGameObj.SetActive(show);
    }

    internal void ShowEndUI(bool show)
    {
        endScreen.gameObject.SetActive(show);
        endScreen.ShowPlayerWinner(GameManager.instance.playerWins);
    }

    internal void ShowShopScreen(bool show)
    {
        shopScreen.gameObject.SetActive(show);
    }
    internal void ShowTargetingScreen(bool show)
    {
        targetingScreen.gameObject.SetActive(show);
        targetingScreen.EnableTargetMode(show);
    }

    public void SelectTarget(SkillStatSO skillReceived)
    {
        Character_Base target = targetingScreen.Target();
        if (target)
        {
            target.ReceiveSkill(skillReceived);
        }
    }
    internal void CreateSkillButton(SkillStatSO skill, PlayerController player)
    {
        GameObject button = GameObject.Instantiate(skillPrefabGo, skillParent);
        UISkillButton skillBtnScript = button.GetComponent<UISkillButton>();
        skillBtnScript.skillBtn.onClick.AddListener(() =>
        {
            skillBtnScript.skill = skill;
            PlayerController.OnSelectSkill?.Invoke(skill);
            bool haveSelectedSkill = player.selectedSkill != null;
            ShowTargetingScreen(haveSelectedSkill);
        });
    }
}
