using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
	public GameObject ButtonWindow;

	Collider2D myCollider;
	Collider2D playerCollider;
	bool isTouching = false;

	protected void ParentStart()
	{

		myCollider = gameObject.GetComponent<Collider2D>();
		playerCollider = GameHandler.instance.player.GetComponent<Collider2D>();
	}
	// Update is called once per frame

	protected void ParentUpdate()
	{
		if (!GameHandler.instance.isInteractionPaused)
		{
			if (!isTouching && myCollider.IsTouching(playerCollider))
			{
				isTouching = true;
				ButtonWindow.SetActive(true);
			}
			else if (isTouching && !myCollider.IsTouching(playerCollider))
			{
				isTouching = false;
				ButtonWindow.SetActive(false);
			}

			if (isTouching && Input.GetButtonDown("Action"))
			{
				Interact();
			}
		}
	}

	protected abstract void Interact();
}
