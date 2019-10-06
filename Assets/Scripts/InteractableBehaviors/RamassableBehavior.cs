using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamassableBehavior : Interactable
{
	public ItemType item;
	public int amount;


	// Start is called before the first frame update
	void Start()
    {
		ParentStart();
	}

    // Update is called once per frame
    void Update()
	{
		ParentUpdate();
	}

	protected override void Interact()
	{
		InventoryHandler.instance.Add(item, amount);
		Destroy(gameObject);
	}
}
