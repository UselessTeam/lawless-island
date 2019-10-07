using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHuman : IActionable
{
    public override void Activate(SelectableOption option)
    {
        InventoryHandler.instance.Add(ItemType.Human, 3);
        HumanHandler.instance.SpawnHuman();
    }
}
