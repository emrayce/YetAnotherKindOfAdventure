using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField]
    protected Animator animator;

    #region getter
    public Animator GetAnimator()
    {
        return animator;
    }
    #endregion
}
