using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	Vector2 direction;
	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		direction = new Vector2(0, 0);
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

		GetComponent<MovingEntity>().Move(direction);
	}
}
