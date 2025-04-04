using System.Collections.Generic;
using System;
using NUnit.Framework;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{

    [SerializeField] private SpriteRenderer WeaponSprite;
    [SerializeField] private List<AttackBase> Attacks;
    [SerializeField] private Stack<AttackBase> combo;
    [SerializeField] private float ComboTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Stack<AttackBase> AddAttack(AttackBase attack)
    {
        combo.Push(attack);
        return combo;
    }

    public void ClearStack()
    {
        combo.Clear();
    }

    public Stack<AttackBase> GetStack()
    {
        return combo;
    }
}
