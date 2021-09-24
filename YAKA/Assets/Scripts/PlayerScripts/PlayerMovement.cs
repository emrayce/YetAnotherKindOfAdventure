using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private RaycastHit hit;

    public void MoveTo(Vector3 position)
    {
        transform.LookAt(new Vector3(position.x, transform.position.y, position.z));
        transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
    }

    public bool IsGrounded()
    {
        Physics.Raycast(transform.position, Vector3.down, out hit);

        return hit.distance < 0.1f;
    }

    public void KeepGrounded()
    {
        if (IsGrounded())
        {
            Vector3 newPosition = transform.position;
            newPosition.y = hit.point.y + 0.01f;
            transform.position = newPosition;
        }
    }

    private void Update()
    {
        KeepGrounded();
    }
}
