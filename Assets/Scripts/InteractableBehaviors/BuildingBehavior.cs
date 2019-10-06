using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBehavior : Interactable
{
	public ItemAmount[] buildingRequirement;
	public struct Transaction
	{
		public ItemAmount[] price;
		public ItemAmount product;
	}
    public List<Transaction> transactions;

	public bool isBuilt = false;



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
		if (!isBuilt)
        {
			if (InventoryHandler.instance.IsEnough(buildingRequirement))
            {
				//TODO Do GUI STUFF
				Build();
			}else
			{
                //TODO
			}
		}else
		{
			//TODO Do GUI STUFF
		}
	}

	void Build()
	{//TODO
		isBuilt = true;
		InventoryHandler.instance.Remove(buildingRequirement);
    }

	void Buy(Transaction transaction)
	{
		if (InventoryHandler.instance.IsEnough(transaction.price))
		{
			InventoryHandler.instance.Remove(transaction.price);
			InventoryHandler.instance.Add(transaction.product);
		}else
		{
		}
	}
}
