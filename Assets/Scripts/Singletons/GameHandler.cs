using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Graphics.GUI;

public class GameHandler : Singleton<GameHandler>
{
    public GameObject player;

    public int selectedTool = 0;
    public List<ItemType> tools;

    public bool guiOpen = false;
    public bool isPhysicsPaused
    {
        get { return guiOpen; }
    }
    public bool isInteractionPaused
    {
        get { return guiOpen; }
    }

    public GUIPanel OpenGui()
    {
        guiOpen = true;
        return GUIHandler.instance.OpenPanel();
    }
    public void CloseGui()
    {
        if (guiOpen)
        {
            guiOpen = false;
            GUIHandler.instance.Close();
        }
    }

    private void Start()
    {
        SoundHandler.instance.PlayMusic("bornForAdventure");
        tools.Add(ItemType.Sword);
        tools.Add(ItemType.Harpoon);
        tools.Add(ItemType.Axe);
        tools.Add( ItemType.Pickaxe);
    }
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            CloseGui();
        }
        for (int i = 0; i < 4; i++)
        {
            if (Input.GetButtonDown("Tool" + (i+1).ToString()))
            {
                selectedTool = i;
                GUIHandler.instance.SelectTool(i);
            }
        }
    }
}
