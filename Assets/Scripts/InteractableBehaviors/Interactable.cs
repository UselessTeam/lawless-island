using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public GameObject ButtonWindow = null;

    Collider2D myCollider;
    Collider2D playerCollider;
    bool isTouching = false;

    protected void ParentStart()
    {
        myCollider = gameObject.GetComponent<Collider2D>();
        UpdateCollider();
    }

    public void UpdateCollider()
    {
        playerCollider = GameHandler.instance.player.GetComponentInParent<Collider2D>();
    }

    protected void ParentUpdate()
    {
        //if (playerCollider == null)
        UpdateCollider();
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
        if(ButtonWindow != null) {
            ButtonWindow.SetActive(true);
        }
    }
    protected virtual void HideWindow()
    {
        if(ButtonWindow != null) {
            ButtonWindow.SetActive(false);
        }
    }

    protected abstract void Interact();
}
