using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(target);
    }

    // Be sure to modify the position after the target moves
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
