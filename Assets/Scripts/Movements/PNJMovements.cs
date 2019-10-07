using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJMovements : MonoBehaviour
{
    public float movementSpeed = 15;

    MovingEntity movingEntity;

    // Start is called before the first frame update
    void Start()
    {
        movingEntity = GetComponentInParent<MovingEntity>();
        movingEntity.speed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
