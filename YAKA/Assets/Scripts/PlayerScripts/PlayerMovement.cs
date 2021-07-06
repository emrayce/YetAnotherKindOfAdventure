using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    public void MoveTo(Vector3 position)
    {
        transform.LookAt(new Vector3(position.x, transform.position.y, position.z));
        transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
    }
}
