using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Player player;

    public LayerMask layers;

    [SerializeField]
    private GameObject targetBar;
    [SerializeField]
    private TargetBarScript targetBarScript;

    // GameObject layers for raycast interractions
    private const int UILayer = 5;
    private const int GroundLayer = 8;
    private const int UnitsLayer = 9;


    protected void FixedUpdate()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;

        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, layers))
        {
            GameObject target = hit.transform.gameObject;
            switch (target.layer)
            {
                case UILayer:
                    Debug.Log("Hi UI layer");
                    // handle UI interraction here
                    break;

                case GroundLayer:
                    Debug.Log("Hi ground layer");
                    //handle pure movement;
                    targetBar.SetActive(false);
                    if (Input.GetMouseButton(0))
                    {
                        player.MoveTo(hit.point);
                    }
                    break;

                case UnitsLayer:
                    Debug.Log("Hi unit layer");
                    DisplayTarget(target);
                    // handle units interractions;
                    break;

                default:
                    // do nothing for now (maybe put the UI here ?)
                    Debug.Log("Hi " + target.name);
                    break;
            }
        }
    }

    private void DisplayTarget(GameObject target)
    {
            Unit unit = target.GetComponent<Unit>();
            targetBarScript.SetUnit(unit);
            targetBar.SetActive(true);
    }
}
