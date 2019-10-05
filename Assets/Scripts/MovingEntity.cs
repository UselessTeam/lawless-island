using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEntity : MonoBehaviour
{
	public Vector2 velocity;

	public float Speed = 10;
	public float Ammortisesment = 0.5F;
	public float Acceleration = 100;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
	}

	public void Move(Vector2 direction)
	{
		if (direction.magnitude > 0)
		{
			velocity += Acceleration * Time.deltaTime * direction;
			if (velocity.magnitude > Speed)
			{
				velocity = velocity.normalized * Speed;
			}
		}
		else
		{
			velocity *= (1 - Ammortisesment);
		}
		transform.position += (Vector3)velocity * Time.deltaTime;
		if (velocity.magnitude < Speed * 0.001)
		{
			velocity = new Vector2();
		}
	}
}
