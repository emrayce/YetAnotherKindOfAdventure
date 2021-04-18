using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
    private const int GroundLayer = 8;
    private const int UnitsLayer = 9;


    protected void FixedUpdate()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;

        if (EventSystem.current.IsPointerOverGameObject())
        {
            // handle specific UI interractions
        }

        else if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, layers))
        {
            GameObject target = hit.transform.gameObject;
            switch (target.layer)
            {
                case GroundLayer:
                    //handle pure movement;
                    targetBar.SetActive(false);
                    if (Input.GetMouseButton(0))
                    {
                        player.MoveTo(hit.point);
                    }
                    break;

                case UnitsLayer:
                    DisplayTarget(target);

                    if (Input.GetMouseButton(0))
                    {
                        if (target.CompareTag("Enemy"))
                        {
                            // if too far from the enemy move towards him
                            if (Vector3.Distance(player.transform.position, hit.point) > player.GetRange())
                            {
                                if (Physics.Raycast(target.transform.position, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
                                {
                                    player.MoveTo(hit.point);
                                }
                            }
                            // if enemy is in player's range stop moving and attack him
                            else
                            {
                                // Attack
                            }
                        }
                    }
                    // handle units interractions
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
