using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureController : BaseController
{
    protected float _speed = 1.0f;
    public int Hp { get; set; } = 100;
    public int MaxHp { get; set; } = 100;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public virtual void OnDamage(BaseController attacker, int damage)
    {
        Hp -= damage;
        if(Hp<=0)
        {
            Hp = 0;
            OnDead();
        }
    }

    protected virtual void OnDead()
    {

    }
}
