using System;
using UnityEngine;

public enum ItemType : int
{
	Wood,
	Mushroom,
	AutreObjetPhallique
}

public class InventoryHandler : Singleton<InventoryHandler>
{
	int[] amounts;
	public Action callback;
	public static int inventoryItemTypeSize = System.Enum.GetNames(typeof(ItemType)).Length;

	void Awake()
	{
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

	public void Remove(ItemType type, int q)
	{
		amounts[(int)type] -= q;
        if (amounts[(int)type]<0)
			Debug.LogError("Quantite negative!");
		if(callback != null) {
			callback.Invoke();
		}
	}

	public bool IsEnough(ItemType type, int q)
	{
        return amounts[(int)type] >= q;
	}

	public int GetQuantity(ItemType type)
	{
		return amounts[(int)type];
	}

}
