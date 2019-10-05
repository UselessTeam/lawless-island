using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamassableBehavior : MonoBehaviour
{
	public GameObject ButtonWindow;

	public ItemType item;
	public int amount;

	Collider2D myCollider;
	Collider2D playerCollider;
	bool isTouching;


	// Start is called before the first frame update
	void Start()
    {
		myCollider = GetComponent<Collider2D>();
		playerCollider = GameHandler.instance.player.GetComponent<Collider2D>();
	}

    // Update is called once per frame
    void Update()
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

		if (isTouching && Input.GetButton("Action"))
		{
			InventoryHandler.instance.Add(item, amount);
			RemoveRamassable();
		}
	}

	void RemoveRamassable()
	{
		//Animation?
		Destroy(gameObject);
	}
}
