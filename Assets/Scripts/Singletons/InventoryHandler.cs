using System;
using UnityEngine;

public enum ItemType : int
{
	Wood,
	Mushroom,
	AutreObjetPhallique
}

[Serializable]
public struct ItemAmount{
	public ItemType type;
	public int amount;
}

public class InventoryHandler : Singleton<InventoryHandler>
{
	int[] amounts;
	public Action callback;
	public static int inventoryItemTypeSize = System.Enum.GetNames(typeof(ItemType)).Length;

	protected override void Awake()
	{
		base.Awake();
		amounts = new int [inventoryItemTypeSize];
	}

	// Update is called once per frame
	void Update()
    {
    }

	public void Add(ItemType type, int q)
	{
		amounts[(int)type] += q;
		if(callback != null) {
			callback.Invoke();
		}
	}
	public void Add(ItemAmount item)
	{
		Add(item.type, item.amount);
	}
	public void Add(ItemAmount[] items)
	{
		foreach (ItemAmount item in items)
		{
			Add(item);
		}
	}

	public void Remove(ItemType type, int q)
	{
		amounts[(int)type] -= q;
        if (amounts[(int)type]<0)
			Debug.LogError("Quantite negative!");
		if(callback != null) {
			callback.Invoke();
		}
	}
	public void Remove(ItemAmount item)
	{
		Remove(item.type, item.amount);
	}
	public void Remove(ItemAmount[] items)
	{
		foreach (ItemAmount item in items)
		{
			Remove(item);
		}
	}

	public bool IsEnough(ItemType type, int q)
	{
        return amounts[(int)type] >= q;
	}
    public bool IsEnough(ItemAmount item)
	{
		return IsEnough(item.type, item.amount);
	}
	public bool IsEnough(ItemAmount[] items)
	{
		foreach (ItemAmount item in items)
		{
			if (!IsEnough(item))
				return false;
		}
		return true;
	}

	public int GetQuantity(ItemType type)
	{
		return amounts[(int)type];
	}

}
