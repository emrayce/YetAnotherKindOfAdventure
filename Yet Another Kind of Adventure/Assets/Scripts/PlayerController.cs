using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Unit
{
    [SerializeField]
    private BarScript healthbar, manabar;


    public LayerMask layers;
    public float distanceBeforeRunning;

    // Start is called before the first frame update
    protected override void Start()
    {
        healthbar.SetMaxValue(hpMax);
        manabar.SetMaxValue(manaMax);
    }

    // Update is called once per frame
    protected override void Update()
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetMaxHealth(hpMax + 10);
            SetMaxMana(manaMax + 10);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetHealth(hp - 10);
            SetMana(mana - 10);
        }
    }


    // Call it when modifying current health (eg: taking damage)
    protected override void SetHealth(int value)
    {
        hp = value;
        healthbar.SetValue(value);
    }

    // Call it when modifying max health (eg: Lvl up)
    protected override void SetMaxHealth(int value)
    {
        hpMax = value;
        hp = value;
        healthbar.SetMaxValue(value);
    }

    // Call it when modifying current mana (eg: casting a spell)
    protected override void SetMana(int value)
    {
        mana = value;
        manabar.SetValue(value);
    }

    // Call it when modifying max mana (eg: Lvl up)
    protected override void SetMaxMana(int value)
    {
        manaMax = value;
        mana = value;
        manabar.SetMaxValue(value);
    }
}
