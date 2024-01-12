using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkillButton : MonoBehaviour
{
    [SerializeField] private GameObject skillActiveGo;
    public Button skillBtn;
    public SkillStatSO skill;

    private bool selected = false;
    private void Awake()
    {
        PlayerController.OnSelectSkill += skillSelected =>
        {
            if (skillSelected == skill) selected = !selected;
            else selected = false;
            ShowEnabled(selected);
        };

        UIManager.OnSendindSkill(skill);
    }
    private void Start() {
        
    }
    public void ShowEnabled(bool show)
    {
        skillActiveGo.SetActive(show);
    }
}
