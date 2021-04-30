using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fighter : Unit
{
    [Header("Fighter Stats")]

    [SerializeField]
    protected int hpMax;
    [SerializeField]
    protected int manaMax;
    protected int hp, mana;

    [SerializeField]
    private float attackSpeed;

    [SerializeField]
    protected int strength, agility, intelligence;

    // minimal distance to attack
    [SerializeField]
    protected float range;

    private Fighter target;


    private int weaponAtk = 5;
    private int armor = 0;




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


    #region FightSystem

    private int BasicAtkDamage()
    {
        return Mathf.CeilToInt(weaponAtk * 0.25f * strength);
    }

    public void DealDamage()
    {
        target.TakeDamage(BasicAtkDamage());
    }

    public void TakeDamage(int damage)
    {
        // Unit wil always take 1 damage when being attacked
        int value = damage == armor ? 1 : damage - armor;
        int newhp = hp < damage ? 0 : hp - damage;
        SetHealth(newhp);
    }

    public IEnumerator BasicAttack()
    {
        Debug.Log("call attack");
        AnimationClip[] animations = animator.runtimeAnimatorController.animationClips;
        animator.SetBool("Attack", true);
        yield return new WaitForSeconds(animations[1].length);
        animator.SetBool("Attack", false);

        target.TakeDamage(BasicAtkDamage());
        //yield return new WaitForSeconds(animations[1].length / 2);
        animator.SetBool("Attack", false);
    }

    public void Attack()
    {
        AnimationClip[] animations = animator.runtimeAnimatorController.animationClips;
        animator.Play("Player|Attack");
        target.TakeDamage(BasicAtkDamage());
    }

    public void SetTarget(Fighter fighter)
    {
        target = fighter;
    }
    #endregion

    #region Getter
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

    public float GetRange()
    {
        return range;
    }

    public float GetAttackSpeed()
    {
        return attackSpeed;
    }

    #endregion
}
