using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Player player;

    public LayerMask movementLayers;
    public LayerMask TargetLayers;

    [SerializeField]
    private GameObject targetBar;
    [SerializeField]
    private TargetBarScript targetBarScript;

    protected void FixedUpdate()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;

        Detect(castPoint);
        
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, movementLayers))
            {
                player.MoveTo(hit.point);
            }
        }
    }

    private void Detect(Ray castPoint)
    {
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, TargetLayers))
        {
            GameObject target = hit.transform.gameObject;
            Unit unit = target.GetComponent<Unit>();
            targetBarScript.SetUnit(unit);
            targetBar.SetActive(true);
        }
        else
        {
            targetBar.SetActive(false);
        }
    }
}
