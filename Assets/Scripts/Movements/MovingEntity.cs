using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEntity : MonoBehaviour
{
    public Vector2 velocity;

    public float speed = 10;
    public float Ammortisesment = 0.5F;
    public float Acceleration = 100;

    Vector2 direction;

    public float takeHitTime = 0.1F;
    public float takeHitSpeed = 200;

    bool isTakingHit = false;
    float takeHitSince;
    Vector2 takeHitDirection;


    // Update is called once per frame
    void Update()
    {

        if (!GameHandler.instance.isPhysicsPaused)
        {
            UpdateCollisions();
            transform.position += (Vector3)velocity * Time.deltaTime;
            if (isTakingHit)
            {
                direction = takeHitDirection;
                if (Time.fixedTime - takeHitSince > takeHitTime)
                    isTakingHit = false;
                velocity = takeHitDirection * takeHitSpeed;
            }
            else if (direction.magnitude > 0.5F)
            {
                velocity += Acceleration * Time.deltaTime * direction;
                if (velocity.magnitude > speed)
                {
                    velocity = velocity.normalized * speed;
                }
            }
            else
            {
                velocity *= (1 - Ammortisesment);
            }

            if (velocity.magnitude < speed * 0.001)
            {
                velocity = new Vector2();
            }
        }
    }

    public void TakeHit(Vector2 direction)
    {
        isTakingHit = true;
        takeHitSince = Time.fixedTime;
        takeHitDirection = direction;
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    public bool IsTakingHit()
    {
        return isTakingHit;
    }

    private Collider2D myCollider;
    private ContactFilter2D contactFilter;
    private RaycastHit2D[] hitBuffer = new RaycastHit2D[16];

    private static readonly float SHELL_RADIUS = 0.02f;
    private static readonly float MIN_CHECK_RADIUS = 0.04f;
    private static readonly float MIN_CHECK_VELOCITY = 0.04f;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponentInChildren<Collider2D>();
        contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    void UpdateCollisions()
    {
        if (velocity.magnitude * Time.deltaTime > MIN_CHECK_VELOCITY)
        {
            int count = myCollider.Cast(velocity / velocity.magnitude, contactFilter, hitBuffer,
                            velocity.magnitude * Time.deltaTime + MIN_CHECK_RADIUS);
            Vector2 normalVector = new Vector2(velocity.y, -velocity.x);
            for (int i = 0; i < count; i++)
            {
                normalVector.Normalize();
                Vector2 currentNormal = hitBuffer[i].normal;
                double currentdistance = hitBuffer[i].distance;
                float dangerousDistance = Mathf.Max(hitBuffer[i].distance , 0);
                float projection = Vector2.Dot(velocity, currentNormal);
                if (dangerousDistance < (-projection) * Time.deltaTime)
                    velocity -= currentNormal * (projection + dangerousDistance / Time.deltaTime);
            }
            foreach (Vector2 vect in new Vector2[] { normalVector, -normalVector })
            {
                count = myCollider.Cast(vect, contactFilter, hitBuffer, SHELL_RADIUS);
                for (int i = 0; i < count; i++)
                    transform.position += (Vector3)(hitBuffer[i].normal * SHELL_RADIUS);
            }
        }
    }
}
