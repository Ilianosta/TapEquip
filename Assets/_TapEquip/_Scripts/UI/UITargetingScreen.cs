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

    public Character_Base Target()
    {
        Character_Base target = null;
        Ray ray = Camera.main.ScreenPointToRay(cursorGO.transform.position);
        RaycastHit rayHit;
        if (Physics.Raycast(ray, out rayHit))
        {
            if (rayHit.collider != null)
            {
                GameObject newTarget = rayHit.collider.gameObject;
                if (newTarget.GetComponent<Character_Base>())
                {
                    target = newTarget.GetComponent<Character_Base>();
                }
            }
        }
        return target;
    }
}
