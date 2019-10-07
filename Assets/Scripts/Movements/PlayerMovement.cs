using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 direction;
    MovingEntity movingEntity;

    public Vector2 facingDirection;
    float timeSinceDiagonal = -10;
    float switchTime = 0.07F;
    // Start is called before the first frame update
    void Start()
    {
        MoveNewHuman();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameHandler.instance.isPhysicsPaused)
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

            if (direction.magnitude > 1)
            {
                timeSinceDiagonal = Time.fixedTime;
                facingDirection = direction;
            }
            else if (direction.magnitude == 1 && Time.fixedTime - timeSinceDiagonal > switchTime)
            {
                facingDirection = direction;
            }

            movingEntity.SetDirection(direction);
        }
    }

    public void MoveNewHuman()
    {
        movingEntity = GetComponentInParent<MovingEntity>();
    }
}
