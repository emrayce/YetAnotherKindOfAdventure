using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
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

    private Vector3 mouse;
    private Ray castPoint;
    private RaycastHit hit;



    protected void FixedUpdate()
    {
        mouse = Input.mousePosition;
        castPoint = Camera.main.ScreenPointToRay(mouse);

        if (EventSystem.current.IsPointerOverGameObject())
        {
            // handle specific UI interractions
        }

        else if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, layers))
        {
            GameObject target = hit.transform.gameObject;
            switch (target.layer)
            {
                case GroundLayer:
                    //handle pure movement;
                    targetBar.SetActive(false);
                    if (Input.GetMouseButton(0))
                    {
                        player.MoveTo(hit.point);
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
    }

    IEnumerator Attack()
    {
        AnimationClip[] animations = player.GetAnimator().runtimeAnimatorController.animationClips;
        lastAttack = Time.time;
        player.GetAnimator().Play("Player|Attack");
        //player.GetAnimator().SetBool("Attack", true);
        yield return new WaitForSeconds(animations[1].length);
        player.DealDamage();
        //player.GetAnimator().SetBool("Attack", false);
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
                        player.MoveTo(hit.point);
                    }
                }
                // if enemy is in player's range stop moving and attack him
                else
                {
                    // Attack
                    if (Time.time - lastAttack >= player.GetAttackSpeed())
                    {
                        StartCoroutine(Attack());
                    }
                }
            }
        }
    }
}
