using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType : int
{
	Wood,
	Mushroom,
	AutreObjetPhallique
}

public class InventoryHandler : Singleton<InventoryHandler>
{
	int[] Quantities;

	// Start is called before the first frame update
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
    {
    }

	void Add(ItemType type, int q)
	{
		Quantities[(int)type] += q;
	}

	void Remove(ItemType type, int q)
	{
		Quantities[(int)type] -= q;
        if (Quantities[(int)type]<0)
			Debug.LogError("Quantite negative!");
	}

	bool IsEnough(ItemType type, int q)
	{
        return Quantities[(int)type] >= q;
	}

	int getQuantity(ItemType type)
	{
		return Quantities[(int)type];
	}

}
