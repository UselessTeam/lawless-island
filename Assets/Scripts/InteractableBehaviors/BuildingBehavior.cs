using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingBehavior : Interactable
{
	public SelectableOption buildingRequirement;

    public SelectableOption[] transactions;

	public GameObject Built;
	public GameObject Unbuilt;

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
		var panel = GameHandler.instance.OpenGui();
		if (!isBuilt)
        {
			panel.Display(new SelectableOption[] { buildingRequirement });
		}else
		{
			panel.Display(transactions);
		}
	}

	public void Build()
	{
		isBuilt = true;
		Unbuilt.SetActive(false);
		Built.SetActive(true);
	}

}
