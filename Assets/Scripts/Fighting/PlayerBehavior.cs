using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : FightingBehavior
{
	PlayerMovement movement;

	public GameObject attackObject;
	public float attackTime;
	public float attackPopDistance;

	bool isAttacking = false;
	float timeSinceAttack = -10;
	Vector2 attackDirection;
	// Start is called before the first frame update
	protected override void Start()
    {
        base.Start();
        movement = GetComponent<PlayerMovement>();
	}

	// Update is called once per frame
	void Update()
	{
		FightingUpdate();
		if (Input.GetButtonDown("Attack") && IsCanAttack())
		{
			isAttacking = true;
			timeSinceAttack = Time.fixedTime;
			attackObject.SetActive(true); //TODO Move the attack :in front of the player
			attackDirection = movement.facingDirection;
			attackObject.transform.localPosition += (Vector3)attackDirection * attackPopDistance;
		}

		if (isAttacking && Time.fixedTime - timeSinceAttack > attackTime)
		{
			isAttacking = false;
			attackObject.SetActive(false);
			attackObject.transform.localPosition = new Vector3();
		}
	}

	public Vector2 GetAttackDirection()
	{
		return attackDirection;
	}

	public override bool IsCanAttack()
	{
		return !isAttacking && !GetComponentInParent<MovingEntity>().IsTakingHit();
	}

	public override void Die()
	{
		Destroy(gameObject);
	}

    public void SetNewPlayer(GameObject newPlayer)
    {
        FightingBehavior newFightStats = newPlayer.GetComponentInChildren<FightingBehavior>();
        hpMax = newFightStats.hpMax;
        hp = newFightStats.getHP;
    }
}
