using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectUnit : MonoBehaviour
{
    [SerializeField]
    private LayerMask layers;

    [SerializeField]
    private GameObject targetBar;
    [SerializeField]
    private TargetBarScript targetBarScript;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;

            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, layers))
            {
                GameObject target = hit.transform.gameObject;
                Unit unit = target.GetComponent<Unit>();
                //Debug.Log(unit.GetHp());
                targetBarScript.SetUnit(unit);
                targetBar.SetActive(true);
            }
            else
            {
                targetBar.SetActive(false);
            }
        }
    }
}
