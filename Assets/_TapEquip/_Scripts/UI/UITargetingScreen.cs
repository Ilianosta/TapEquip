using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITargetingScreen : MonoBehaviour
{
    [SerializeField] GameObject cursorGO;
    private bool isTargeting;
    public void EnableTargetMode(bool show)
    {
        isTargeting = show;
        cursorGO.SetActive(show);
    }
    
    private void Update()
    {
        if (isTargeting)
        {
            cursorGO.transform.position = Input.mousePosition;
        }
    }
}
