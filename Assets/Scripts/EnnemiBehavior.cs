using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiBehavior : MonoBehaviour
{
    public float VisionRange;
	Transform playerTransform;
	// Start is called before the first frame update
	void Start()
    {
		playerTransform = GameHandler.instance.player.transform;
	}

    // Update is called once per frame
    void Update()
    {
		if ((playerTransform.position - transform.position).magnitude < VisionRange)
		{
			GetComponent<MovingEntity>().Move(
								(playerTransform.position - transform.position).normalized);

		}
	}
}
