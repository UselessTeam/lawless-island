using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamassableBehavior : MonoBehaviour
{
	public GameObject ButtonWindow;

	Collider2D collider;
	Collider2D playerCollider;
	bool isTouching;
	// Start is called before the first frame update
	void Start()
    {
		collider = GetComponent<Collider2D>();
		playerCollider = GameHandler.instance.player.GetComponent<Collider2D>();
	}

    // Update is called once per frame
    void Update()
	{
		ContactPoint2D[]  cols = new ContactPoint2D[16];
		collider.GetContacts(cols);
        foreach (ContactPoint2D col in cols)
        {
            if (col.rigidbody)
                print(col.rigidbody.gameObject.name);
		}
		if (!isTouching && collider.IsTouching(playerCollider))
		{
			isTouching = true;
			ButtonWindow.SetActive(true);
		}
		else if (isTouching && !collider.IsTouching(playerCollider))
		{
			isTouching = false;
			ButtonWindow.SetActive(false);
		}
	}
}
