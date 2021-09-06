﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerManager : MonoBehaviour
{
    private Player player;

    public LayerMask layers;

    [SerializeField]
    private GameObject targetBar;
    [SerializeField]
    private TargetBarScript targetBarScript;

    // GameObject layers for raycast interractions
    private const int GroundLayer = 8;
    private const int UnitsLayer = 9;

    private float lastAttack;

    private Ray castPoint;
    private RaycastHit hit;

    private InputHandler inputHandler;
    private PlayerMovement playerMovement;


    // store the routine the playerManager will have to manage
    private Coroutine coroutine = null;

    private void Start()
    {
        inputHandler = gameObject.GetComponent<InputHandler>();
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        player = gameObject.GetComponent<Player>();
    }


    // calling in fixed Update because motion is made by modifying directly
    protected void FixedUpdate()
    {
        castPoint = inputHandler.MouseRay();

        // Handling players action when outside of the UI
        if (!inputHandler.MouseOverUI()
            & Physics.Raycast(castPoint, out hit, Mathf.Infinity, layers))
        {
            GameObject target = hit.transform.gameObject;
            TargetHandler(target);
        }
    }

    private void TargetHandler(GameObject target)
    {
        switch (target.layer)
        {
            case GroundLayer:
                //handle pure movement;
                targetBar.SetActive(false);
                if (Input.GetMouseButton(0))
                {
                    // cancel current attack
                    if (player.GetAnimator().GetBool("Attack"))
                    {
                        Debug.Log("Stop attack");
                        StopCoroutine(coroutine);
                        StopCoroutine("BasicAttack");
                        player.GetAnimator().SetBool("Attack", false);
                    }

                    playerMovement.MoveTo(hit.point);
                }
                break;

            case UnitsLayer:
                // handle units interractions
                DisplayTarget(target);
                UnitInteraction(target);

                break;

            default:
                // do nothing for now (maybe put the UI here ?)
                Debug.Log("Hi " + target.name);
                break;
        }
    }

    private void DisplayTarget(GameObject target)
    {
        Fighter unit = target.GetComponent<Fighter>();
        targetBarScript.SetUnit(unit);
        targetBar.SetActive(true);
    }

    private void UnitInteraction(GameObject target)
    {
        if (Input.GetMouseButton(0))
        {
            if (target.CompareTag("Enemy"))
            {
                player.SetTarget(target.GetComponent<Fighter>());

                // if too far from the enemy move towards him
                if (Vector3.Distance(player.transform.position, hit.point) > player.GetRange())
                {
                    if (Physics.Raycast(target.transform.position, Vector3.down, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
                    {
                        playerMovement.MoveTo(hit.point);
                    }
                }
                // if enemy is in player's range stop moving and attack him
                else
                {
                    // Look at the target
                    Vector3 targetGrounded = new Vector3(target.transform.position.x, 0, target.transform.position.z);
                    transform.LookAt(targetGrounded);

                    // Attack
                    if (Time.time - lastAttack >= player.GetAttackSpeed())
                    {
                        player.Attack();
                        lastAttack = Time.time;
                    }
                }
            }
        }
    }
}
