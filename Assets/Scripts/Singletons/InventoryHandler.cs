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
	int[] Amounts;

	// Start is called before the first frame update
	void Start()
	{
		int a = System.Enum.GetNames(typeof(ItemType)).Length;
		Amounts = new int [a];
	}

	// Update is called once per frame
	void Update()
    {
    }

	public void Add(ItemType type, int q)
	{
		Amounts[(int)type] += q;
	}

	public void Remove(ItemType type, int q)
	{
		Amounts[(int)type] -= q;
        if (Amounts[(int)type]<0)
			Debug.LogError("Quantite negative!");
	}

	public bool IsEnough(ItemType type, int q)
	{
        return Amounts[(int)type] >= q;
	}

	public int getQuantity(ItemType type)
	{
		return Amounts[(int)type];
	}

}
