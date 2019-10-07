using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJBehavior : FightingBehavior
{
    protected override void Start() {
        hpMax = Random.Range(HumanHandler.instance.minHP, HumanHandler.instance.maxHP);
        base.Start();
    }

}
