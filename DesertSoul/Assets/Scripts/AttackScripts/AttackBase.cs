using System.Collections.Generic;
using UnityEngine;

public class AttackBase : MonoBehaviour
{
    [SerializeField] private Stack<AttackBase> requirments;
    [SerializeField] private int damage;
    [SerializeField] private float AtkTime;
    [SerializeField] private AttackType type;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public AttackType getAttackType()
    {
        return type;
    }
}
