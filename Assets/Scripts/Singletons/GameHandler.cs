using UnityEngine;

public class GameHandler : Singleton<GameHandler>
{
	public GameObject player;
	public bool guiOpen = false;

    public bool isPhysicsPaused{
		get { return guiOpen; }
	}
    public bool isInteractionPaused{
		get { return guiOpen; }
	}

	public Graphics.GUI.GUIPanel OpenGui()
	{
		guiOpen = true;
		return Graphics.GUI.GUI.instance.OpenPanel();
	}
	public void CloseGui()
	{
		if (guiOpen)
		{
			guiOpen = false;
			Graphics.GUI.GUI.instance.Close();
		}
	}

    void Update() {
		if (Input.GetButtonDown("Cancel"))
		{
			CloseGui();
		}
	}
}
