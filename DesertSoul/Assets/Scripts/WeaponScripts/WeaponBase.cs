using System.Collections.Generic;
using System;
using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu]
public class WeaponBase : ScriptableObject
{

    [SerializeField] private SpriteRenderer WeaponSprite;
    [SerializeField] protected List<AttackBase> Attacks;
    [SerializeField] protected List<AttackType> combo;
    [SerializeField] private float ComboTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Attacks = new List<AttackBase>();
        combo = new List<AttackType>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddAttack(AttackType attack, Animator anim)
    {
        bool match = true;

        for(int i = 0; i < Attacks.Count; i++)
        {
            if (Attacks[i].getAttackType() == attack)
            {
                if (combo.Count == Attacks[i].getRequire().Count)
                {
                    for (int j = 0; j < Attacks[i].getRequire().Count; j++)
                    {
                        if (combo[j] != Attacks[i].getRequire()[j])
                        {
                            match = false;
                            break;
                        }
                    }
                    if (match)
                    {
                        anim.SetInteger("Attack", Attacks[i].getID());
                        anim.SetBool("isAttacking", true);
                        Attacks[i].doAttack();
                        combo.Add(attack);
                        float count = 0;

                        while (count < Attacks[i].getTime())
                        {
                            count += Time.deltaTime;
                        }
                        //anim.SetBool("isAttacking", false);
                        return;
                    }
                }
            }
        }
        //if no moves are found that equal the current combo, clear the combo and run the function again to preform a basic move
        EndCombo();
        //AddAttack(attack, anim);
        return;
    }

    public void EndCombo()
    {
        combo.Clear();
    }

    public List<AttackType> GetCombo()
    {
        return combo;
    }
}
