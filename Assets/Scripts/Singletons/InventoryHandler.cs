using System;
using UnityEngine;

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
        if (Input.GetKeyDown("m"))
            for (int i = 0; i < inventoryItemTypeSize; i++)
                amounts[i] += 10;

        if (Input.GetKeyDown("k"))
            GameHandler.instance.player.GetComponent<PlayerBehavior>().Die();
    }

	public void Add(ItemType type, int q)
	{
		amounts[(int)type] += q;
		if(callback != null) {
			callback.Invoke();
		}
	}
	public void Add(ItemStack item)
	{
		Add(item.type, item.amount);
	}
	public void Add(ItemStack[] items)
	{
		foreach (ItemStack item in items)
		{
			Add(item);
		}
	}
	public void Add(ItemList items)
	{
		foreach (ItemStack item in items.ToArray())
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
	public void Remove(ItemStack item)
	{
		Remove(item.type, item.amount);
	}
	public void Remove(ItemStack[] items)
	{
		foreach (ItemStack item in items)
		{
			Remove(item);
		}
	}
	public void Remove(ItemList items)
	{
		foreach (ItemStack item in items.ToArray())
		{
			Remove(item);
		}
	}

	public bool IsEnough(ItemType type, int q)
	{
        return amounts[(int)type] >= q;
	}
    public bool IsEnough(ItemStack item)
	{
		return IsEnough(item.type, item.amount);
	}
	public bool IsEnough(ItemStack[] items)
	{
		foreach (ItemStack item in items)
		{
			if (!IsEnough(item))
				return false;
		}
		return true;
	}
	public bool IsEnough(ItemList items)
	{
		foreach (ItemStack item in items.ToArray())
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
