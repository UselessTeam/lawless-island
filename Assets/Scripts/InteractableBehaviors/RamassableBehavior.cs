using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamassableBehavior : Interactable
{
    public ItemType item;
    public int amount;

    public bool isRequirement = false;
    public ItemType requirement;
    public SpriteRenderer windowRenderer;

    // Start is called before the first frame update
    void Start()
    {
        ParentStart();
    }

    protected override void ShowWindow()
    {
        if (isRequirement)
        {
            if (!InventoryHandler.instance.IsEnough(requirement, 1))
            {
                windowRenderer.color = Color.red;
            }
            else
            {
                windowRenderer.color = Color.white;
            }
        }
        base.ShowWindow();
    }

    // Update is called once per frame
    void Update()
    {
        ParentUpdate();
    }

    protected override void Interact()
    {
        if (!isRequirement || InventoryHandler.instance.IsEnough(requirement, 1))
        {
            InventoryHandler.instance.Add(item, amount);
            Destroy(gameObject);
        }
    }
}
