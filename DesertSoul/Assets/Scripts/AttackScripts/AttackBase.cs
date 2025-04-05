using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AttackBase : ScriptableObject
{
    [SerializeField] protected List<AttackType> requirments;
    [SerializeField] private int damage;
    [SerializeField] private float AtkTime;
    [SerializeField] private AttackType type;
    [SerializeField] private int attackID;

    public AttackType getAttackType()
    {
        return type;
    }

    public List<AttackType> getRequire()
    {
        return requirments;
    }

    public void doAttack()
    {

    }

    public int getID()
    { 
        return attackID; 
    }

    public float getTime()
    {
        return AtkTime;
    }
}
