using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class InputHandler : MonoBehaviour
{
    private Vector3 mouse;

    public Ray MouseRay()
    {
        mouse = Input.mousePosition;

        return Camera.main.ScreenPointToRay(mouse);
    }

    public bool MouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
