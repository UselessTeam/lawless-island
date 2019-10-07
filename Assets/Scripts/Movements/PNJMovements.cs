using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJMovements : MonoBehaviour
{
    float movementSpeed;
    public float movementRate = 3;

    float timeSinceLastMove = 0;
    float randTime;
    Vector3 goingTo;
    Vector3 direction;

    MovingEntity movingEntity;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = Random.Range(HumanHandler.instance.minSpeed, HumanHandler.instance.maxSpeed);

        movingEntity = GetComponentInParent<MovingEntity>();
        movingEntity.speed = movementSpeed;

        randTime = Random.Range(-20 / movementRate, 20 / movementRate);
    }

    // Update is called once per frame
    void Update()
    {
        movingEntity.SetDirection(direction);
        if (movementRate > 0 && Time.fixedTime - timeSinceLastMove > 60 / movementRate + randTime)
        {
            randTime = Random.Range(-20 / movementRate, 20 / movementRate);
            goingTo = HumanHandler.instance.GetComponent<SpawnZone>().GeneratePosition();
            direction = (goingTo - transform.parent.position).normalized;
            timeSinceLastMove = Time.fixedTime;
        }
        if (Vector3.Dot((goingTo - transform.parent.position), direction) <= 0)
            direction = Vector3.zero;
    }
}
