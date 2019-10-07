using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEntity : MonoBehaviour
{
	public Vector2 velocity;

	public float speed = 10;
	public float Ammortisesment = 0.5F;
	public float Acceleration = 100;

	Vector2 direction;

	public float takeHitTime = 0.1F;
	public float takeHitSpeed = 200;

	bool isTakingHit = false;
	float takeHitSince;
	Vector2 takeHitDirection;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if(!GameHandler.instance.isPhysicsPaused)
        {
			if (isTakingHit)
			{
				direction = takeHitDirection;
				if (Time.fixedTime - takeHitSince > takeHitTime)
					isTakingHit = false;
				velocity = takeHitDirection * takeHitSpeed;
			}
			else if (direction.magnitude > 0.5F)
			{
				velocity += Acceleration * Time.deltaTime * direction;
				if (velocity.magnitude > speed)
				{
					velocity = velocity.normalized * speed;
				}
			}
			else
			{
				velocity *= (1 - Ammortisesment);
			}

			transform.position += (Vector3)velocity * Time.deltaTime;
			if (velocity.magnitude < speed * 0.001)
			{
				velocity = new Vector2();
			}
		}
	}

	public void TakeHit(Vector2 direction)
	{
		isTakingHit = true;
		takeHitSince = Time.fixedTime;
		takeHitDirection = direction;
	}

	public void SetDirection(Vector2 direction)
	{
		this.direction = direction;
	}

	public bool IsTakingHit()
	{
		return isTakingHit;
	}
}
