using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanHandler : Singleton<HumanHandler>
{
    public List<GameObject> humanArray = new List<GameObject>();
    void Start()
    {
        //humanArray.AddRange(GetComponentsInChildren<GameObject>());
        //NewPlayer();
    }

    public void SpawnHuman()
    {
        humanArray.Add(GetComponent<SpawnZone>().SpawnOne());
        InventoryHandler.instance.Add(ItemType.Human, 1);
    }

    public void KillOne()
    {
        Destroy(
            humanArray[RandomHuman()]);
    }

    public void NewPlayer()
    {
        GameObject newPlayer = humanArray[RandomHuman()];
        GameHandler.instance.player.GetComponent<PlayerBehavior>().SetNewPlayer(newPlayer);

        newPlayer.transform.parent = null;
        GameHandler.instance.player.transform.SetParent(newPlayer.transform);
        newPlayer.transform.Find("PNJ").gameObject.SetActive(false);
    }

    public int RandomHuman()
    {
        return Random.Range(0, InventoryHandler.instance.GetQuantity(ItemType.Human));
    }

}