using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanHandler : Singleton<HumanHandler>
{
    public List<GameObject> humanArray = new List<GameObject>();

    public int minSpeed;
    public int maxSpeed;
    public int minHP;
    public int maxHP;

    void Start()
    {
        //humanArray.AddRange(GetComponentsInChildren<GameObject>());
        InventoryHandler.instance.Add(ItemType.Human, humanArray.Count + 1);
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
        int chosenOne = RandomHuman();
        Transform newPlayer = humanArray[chosenOne].transform;
        Transform playerTrsfm = GameHandler.instance.player.transform;
        Transform oldPlayer = playerTrsfm.parent;

        playerTrsfm.GetComponent<PlayerBehavior>().SetNewPlayer(newPlayer);

        newPlayer.parent = null;
        playerTrsfm.SetParent(newPlayer.transform);
        newPlayer.Find("PNJ").gameObject.SetActive(false);
        humanArray.RemoveAt(chosenOne);

        oldPlayer.parent = transform;
        oldPlayer.Find("PNJ").gameObject.SetActive(true);
        humanArray.Add(oldPlayer.gameObject);

        playerTrsfm.GetComponent<PlayerMovement>().MoveNewHuman();
        playerTrsfm.localPosition = Vector3.zero;
    }

    public int RandomHuman()
    {
        return Random.Range(0, InventoryHandler.instance.GetQuantity(ItemType.Human));
    }

    private void Update()
    {/*
        if (Input.GetButtonDown("Cancel"))
            NewPlayer(); */

    }

}