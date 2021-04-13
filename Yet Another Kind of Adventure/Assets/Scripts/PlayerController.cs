using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public LayerMask layers;
    public float distanceBeforeRunning;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, layers))
            {
                float step = speed * Time.deltaTime;
                if (Vector3.Distance(transform.position, hit.point) > distanceBeforeRunning)
                {
                    step *= 2;
                }

                transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
                transform.position = Vector3.MoveTowards(transform.position, hit.point, step);
            }
        }
    }
}
