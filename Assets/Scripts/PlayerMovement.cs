using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float Speed;
	public float Ammortisesment;
	public float Acceleration;

	public Vector2 velocity;
	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		transform.position += (Vector3)velocity * Time.deltaTime;
		if (velocity.magnitude < Speed * 0.001)
		{
			velocity = new Vector2();
		}
		Vector2 direction = new Vector2(0, 0);
		if (Input.GetButton("Up"))
		{
			direction.y += 1;
		}
		if (Input.GetButton("Down"))
		{
			direction.y -= 1;
		}
		if (Input.GetButton("Right"))
		{
			direction.x += 1;
		}
		if (Input.GetButton("Left"))
		{
			direction.x -= 1;
		}

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
	}
}
