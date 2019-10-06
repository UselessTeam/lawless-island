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

	protected void ParentUpdate()
	{
		if (!GameHandler.instance.isInteractionPaused)
		{
			if (!isTouching && myCollider.IsTouching(playerCollider))
            {
                isTouching = true;
                ShowWindow();
			}
			else if (isTouching && !myCollider.IsTouching(playerCollider))
			{
				isTouching = false;
                HideWindow();
			}

			if (isTouching && Input.GetButtonDown("Action"))
			{
				Interact();
			}
		}
	}

    protected virtual void ShowWindow()
    {
        ButtonWindow.SetActive(true);
    }
    protected virtual void HideWindow()
    {
        ButtonWindow.SetActive(false);
    }

    protected abstract void Interact();
}
