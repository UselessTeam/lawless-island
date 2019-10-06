using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
	public Vector2 fixCameraExtent;
    public float cameraSpeed = 10;

    PlayerMovement player;
	void Start()
    {
        player = GameHandler.instance.player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 diff = (Vector2) player.transform.position - CameraScript.position;
        float maxMovement = cameraSpeed * Time.fixedDeltaTime;
        if (Mathf.Abs(diff.x) > fixCameraExtent.x)
        {
            CameraScript.position.x += (diff.x > 0) ? Mathf.Min(diff.x - fixCameraExtent.x, maxMovement) : Mathf.Max(-maxMovement, diff.x + fixCameraExtent.x);
        }
        if (Mathf.Abs(diff.y) > fixCameraExtent.y)
        {
            CameraScript.position.y += (diff.y > 0) ? Mathf.Min(diff.y - fixCameraExtent.y, maxMovement) : Mathf.Max(-maxMovement, diff.y + fixCameraExtent.y);
        }
    }
}
