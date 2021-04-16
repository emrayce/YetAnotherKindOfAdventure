using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Player player;
    public LayerMask layers;

    protected void FixedUpdate()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, layers))
            {
                player.MoveTo(hit.point);
            }
        }
    }
}
