using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJInterraction : Interactable
{
    [SerializeField]
    private GameObject randomText = null;

    void Start()
    {
        ParentStart();
    }

    void Update()
    {
        ParentUpdate();
    }

    protected override void ShowWindow()
    {
        Instantiate(randomText, transform);
    }

    protected override void Interact()
    {
        Instantiate(randomText, transform);
    }
}
