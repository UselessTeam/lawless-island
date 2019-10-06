using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
	PlayerMovement movement;

	public GameObject AttackObject;
	public float attackTime;

	bool isAttacking = false;
	float timeSinceAttack = -10;
	// Start is called before the first frame update
	void Start()
    {
		movement = GetComponent<PlayerMovement>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Attack") && IsCanAttack())
		{
			isAttacking = true;
			timeSinceAttack = Time.fixedTime;
			AttackObject.SetActive(true); //TODO Move the attack :in front of the player
		}

		if (isAttacking && Time.fixedTime - timeSinceAttack > attackTime)
		{
			isAttacking = false;
			AttackObject.SetActive(false);
		}
	}

	public bool IsCanAttack()
	{
        return !isAttacking && !GetComponent<MovingEntity>().IsTakingHit();
	}
}
