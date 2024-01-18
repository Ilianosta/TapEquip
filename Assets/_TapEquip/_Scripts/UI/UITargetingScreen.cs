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
            if (Input.GetButtonDown("Fire1"))
            {
                PlayerController.OnCastSkill?.Invoke();
            }
        }
    }

    public Character_Base Target()
    {
        Character_Base target = null;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(cursorGO.transform.position.x, cursorGO.transform.position.y, Camera.main.transform.position.z));
        RaycastHit rayHit;
        if (Physics.Raycast(ray, out rayHit))
        {
            if (rayHit.collider != null)
            {
                GameObject newTarget = rayHit.collider.gameObject;
                Debug.Log("Target scan");
                if (newTarget.GetComponent<Character_Base>())
                {
                    Debug.Log("Target located");
                    target = newTarget.GetComponent<Character_Base>();
                }
            }
        }
        if (!target) Debug.Log("Target not founded");
        return target;
    }
}
