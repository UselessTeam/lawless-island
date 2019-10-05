using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiBehavior : MonoBehaviour
{
    public float VisionRange;
	Transform playerTransform;
	MovingEntity movingEntity;
	// Start is called before the first frame update
	void Start()
    {
		playerTransform = GameHandler.instance.player.transform;
		movingEntity = GetComponent<MovingEntity>();
	}

    // Update is called once per frame
    void Update()
    {
		if ((playerTransform.position - transform.position).magnitude < VisionRange)
		{
			movingEntity.Move(
                (playerTransform.position - transform.position).normalized);

		}
	}
}
