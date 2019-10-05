using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
	PlayerMovement movement;
	// Start is called before the first frame update
	void Start()
    {
		movement = GetComponent<PlayerMovement>();
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButtonDown("Attack"))
		{

		}
	}
}
