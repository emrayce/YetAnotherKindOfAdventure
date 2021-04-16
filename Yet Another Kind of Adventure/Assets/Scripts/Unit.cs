using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    [SerializeField]
    protected int hpMax, manaMax;
 
    protected int hp, mana;
    
    [SerializeField]
    protected int strength, agility, intelligence;

    // movement speed
    [SerializeField]
    protected float speed;

    // minimal distance to attack
    [SerializeField]
    protected float range;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        hp = hpMax;
        mana = manaMax;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    // Call it when modifying current health (eg: taking damage)
    protected virtual void SetHealth(int value)
    {
        hp = value;
    }

    // Call it when modifying max health (eg: Lvl up)
    protected virtual void SetMaxHealth(int value)
    {
        hpMax = value;
        hp = value;
    }

    // Call it when modifying current mana (eg: casting a spell)
    protected virtual void SetMana(int value)
    {
        mana = value;
    }

    // Call it when modifying max mana (eg: Lvl up)
    protected virtual void SetMaxMana(int value)
    {
        manaMax = value;
        mana = value;
    }

    public int GetHpMax()
    {
        return hpMax;
    }

    public int GetHp()
    {
        return hp;
    }

    public int GetManaMax()
    {
        return manaMax;
    }

    public int GetMana()
    {
        return mana;
    }
}
