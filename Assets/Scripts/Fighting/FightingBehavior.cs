using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FightingBehavior : MonoBehaviour
{
	public int hp = 20;
	public int damage = 7;
	// Start is called before the first frame update

	public void TakeDamage(int damage)
	{
		hp -= damage;

	}
	// Update is called once per frame
	protected void FightingUpdate()
    {
        if(hp <= 0)
			Die();
	}

	public virtual bool IsFlickering()
	{
		return GetComponent<MovingEntity>().IsTakingHit();
	}

	public virtual bool IsCanAttack()
	{
		return !GetComponent<MovingEntity>().IsTakingHit();
	}

	public abstract void Die();
}
