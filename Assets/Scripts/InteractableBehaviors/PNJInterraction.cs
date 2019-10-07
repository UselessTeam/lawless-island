using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJInterraction : Interactable
{
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

    }
}
