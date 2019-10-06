using Graphics.GUI;
using UnityEngine;

public class BuildingBehavior : Interactable
{
	public SelectableOption buildingRequirement;
    public SelectableOption[] transactions;

	public GameObject Built;
	public GameObject Unbuilt;

	public bool isBuilt = false;

	void Awake() {
		Unbuilt.SetActive(!isBuilt);
		Built.SetActive(isBuilt);
	}

	void Start()
	{
		ParentStart();
	}

	void Update()
	{
		ParentUpdate();
	}

	protected override void Interact()
    {
		GUIPanel panel = GameHandler.instance.OpenGui();
		if (!isBuilt)
        {
            buildingRequirement.onSelected.boundBuilding = this;
            panel.Display(new SelectableOption[] { buildingRequirement });
		} else {
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
