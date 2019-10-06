using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : IActionable
{
	// Start is called before the first frame update
	public override void Activate(SelectableOption option)
	{
        InventoryHandler.instance.Add(option.createdItem);
    }
}
