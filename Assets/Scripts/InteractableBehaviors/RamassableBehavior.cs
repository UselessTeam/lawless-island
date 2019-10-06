using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamassableBehavior : Interactable
{
	public ItemType item;
	public int amount;
    public ItemType requirement;

    // Start is called before the first frame update
    void Start()
    {
		ParentStart();
    }

    protected override void ShowWindow()
    {
        base.ShowWindow();

        if (!InventoryHandler.instance.IsEnough(requirement, 1))
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.white;
        }
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
