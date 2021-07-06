using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // movement speed
    [SerializeField]
    protected float speed;

    [SerializeField]
    protected Animator animator;

    #region getter
    public Animator GetAnimator()
    {
        return animator;
    }
    #endregion
}
