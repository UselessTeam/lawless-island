﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiBehavior : FightingBehavior
{
    public float VisionRange;

	Transform playerTransform;
	Collider2D playerCollider;

	PlayerBehavior playerBehavior;
	Collider2D attackCollider;

	MovingEntity movingEntity;
	Collider2D myCollider;

	// Start is called before the first frame update
	void Start()
    {
		playerTransform = GameHandler.instance.player.transform;
		playerCollider = GameHandler.instance.player.GetComponent<Collider2D>();
		playerBehavior = GameHandler.instance.player.GetComponent<PlayerBehavior>();
		attackCollider = playerBehavior.attackObject.GetComponent<Collider2D>();
		movingEntity = GetComponent<MovingEntity>();
		myCollider = GetComponent<Collider2D>();
	}

	// Update is called once per frame
	void Update()
	{
		FightingUpdate();
		Vector2 toPlayer = (Vector2)(playerTransform.position - transform.position);
		if (toPlayer.magnitude < VisionRange)
		{
			movingEntity.SetDirection(toPlayer.normalized);

		}
		if (!IsFlickering() && myCollider.IsTouching(attackCollider))
		{
			HitSelf(playerBehavior.GetAttackDirection());
		}
		else if (IsCanAttack() && myCollider.IsTouching(playerCollider))
		{
			HitPlayer(toPlayer);
		}
	}

	void HitPlayer(Vector2 toPlayer)
    {
		playerTransform.GetComponent<MovingEntity>().TakeHit(toPlayer.normalized);
		playerBehavior.TakeDamage(damage);
	}
	void HitSelf(Vector2 direction)
	{
		GetComponent<MovingEntity>().TakeHit(direction);
		TakeDamage(playerBehavior.damage);
	}

    public override void Die()
	{
		Destroy(gameObject);
	}

}