using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;

	public GameObject player;

	// Start is called before the first frame update
	void Awake()
	{
		instance = this;
	}

    void Start()
	{

	}

    // Update is called once per frame
    void Update()
    {

    }
}
