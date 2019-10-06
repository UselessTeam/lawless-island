using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemData {
    public static int itemTypeSize = System.Enum.GetNames(typeof(ItemType)).Length;
}

public enum ItemType {
    Food,
    Humans,
    Stick,
    Stone,
    Mushroom,
    Berry,
    Flower,
    Crab,
    Wood,
    Ore,
    Metal,
    Shadow,
    Torch,
    Axe,
    Spear,
    Pickaxe,
    Sword,
    Medal
}

[Serializable]
public struct ItemStack {
    public ItemType type;
    public int amount;

    public ItemStack(ItemType type, int amount) {
        this.type = type;
        this.amount = amount;
    }

    public static ItemStack operator+(ItemStack stackA, ItemStack stackB) {
        if(stackA.type != stackB.type) {
            Debug.LogAssertion("Can't combine stacks of types "+stackA.type+" and "+stackB.type);
            return stackA;
        }
        return new ItemStack(stackA.type, stackA.amount + stackB.amount);
    }

    public static ItemStack operator-(ItemStack stackA, ItemStack stackB) {
        if(stackA.type != stackB.type) {
            Debug.LogAssertion("Can't diffirenciate stacks of types "+stackA.type+" and "+stackB.type);
            return stackA;
        }
        int newAmount = stackA.amount - stackB.amount;
        if(newAmount < 0) {
            Debug.LogAssertion("Can't remove more items than there is!");
            newAmount = 0;
        }
        return new ItemStack(stackA.type, newAmount);
    }

    public override string ToString() {
        return amount.ToString() + "x" + type.ToString();
    }
}

public class ItemList {
    private List<ItemStack> itemStacks;

    public int length { get {return itemStacks.Count;}}

    public ItemList()
    {
        itemStacks = new List<ItemStack>();
    }

    public ItemList(ICollection<ItemStack> items) {
        itemStacks = new List<ItemStack>(items);
    }

    private int Find(ItemType type) {
        for(int i = 0; i < itemStacks.Count; i++) {
            if(itemStacks[i].type == type) {
                return i;
            }
        }
        return -1;
    }

    public void Add(ItemType type, int q)
    {
        Add(new ItemStack(type, q));
    }

    public void Add(ItemStack itemStack)
    {
        int i = Find(itemStack.type);
        if(i > 0) {
            itemStacks[i] += itemStack;
        } else {
            itemStacks.Add(itemStack);
        }
    }

    public void Add(ItemStack[] items)
    {
        foreach (ItemStack item in items)
        {
            Add(item);
        }
    }

    public void Remove(ItemType type, int q)
    {
        Remove(new ItemStack(type, q));
    }

    public void Remove(ItemStack itemStack)
    {
        int i = Find(itemStack.type);
        if(i > 0) {
            ItemStack newStack = itemStacks[i] - itemStack;
            if(newStack.amount == 0) {
                itemStacks.RemoveAt(i);
            } else {
                itemStacks[i] += newStack;
            }
        } else {
            Debug.LogError("No such item " + itemStack + "!");
        }
    }

    public void Remove(ICollection<ItemStack> items)
    {
        foreach (ItemStack item in items)
        {
            Remove(item);
        }
    }

    public void Remove(ItemList items)
    {
        foreach (ItemStack item in items.itemStacks)
        {
            Remove(item);
        }
    }

    public bool IsEnough(ItemType type, int q)
    {
        return GetQuantity(type) >= q;
    }

    public bool IsEnough(ItemStack item)
    {
        return GetQuantity(item.type) >= item.amount;
    }

    public bool IsEnough(ICollection<ItemStack> items)
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
        foreach (ItemStack item in items.itemStacks)
        {
            if (!IsEnough(item))
                return false;
        }
        return true;
    }

    public int GetQuantity(ItemType type)
    {
        int i = Find(type);
        return i > 0 ? itemStacks[i].amount : 0;
    }

    public ItemStack[] ToArray(){
        return itemStacks.ToArray();
    }

}