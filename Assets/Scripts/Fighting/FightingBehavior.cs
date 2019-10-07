using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FightingBehavior : MonoBehaviour
{
    public int hpMax = 20;
    protected int hp;
    public int getHP{ get { return hp; } }
    public int damage = 7;
    public int armor = 0;
    // Start is called before the first frame update

    protected virtual void Start()
    {
        hp = hpMax;
    }

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
		return !GetComponentInParent<MovingEntity>().IsTakingHit();
	}

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
