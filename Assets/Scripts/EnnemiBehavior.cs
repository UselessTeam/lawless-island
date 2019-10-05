using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiBehavior : MonoBehaviour
{
    public float VisionRange;
	public int hp = 20;
	public int damage = 1;

	Transform playerTransform;
	Collider2D playerCollider;

	MovingEntity movingEntity;
	Collider2D myCollider;

	// Start is called before the first frame update
	void Start()
    {
		playerTransform = GameHandler.instance.player.transform;
		playerCollider = GameHandler.instance.player.GetComponent<Collider2D>();
		movingEntity = GetComponent<MovingEntity>();
		myCollider = GetComponent<Collider2D>();
	}

    // Update is called once per frame
    void Update()
    {
		Vector2 toPlayer = (Vector2)(playerTransform.position - transform.position);
		if (toPlayer.magnitude < VisionRange)
		{
			movingEntity.SetDirection(toPlayer.normalized);

		}

		if (myCollider.IsTouching(playerCollider))
		{
			HitPlayer(toPlayer);
		}
	}

	void HitPlayer(Vector2 toPlayer)
    {
		playerTransform.GetComponent<MovingEntity>().TakeHit(toPlayer.normalized);
	}
}
