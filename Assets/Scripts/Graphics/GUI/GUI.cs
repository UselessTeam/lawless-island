using UnityEngine;

public class GUI : MonoBehaviour
{
    public Canvas canvas;

    void Start()
    {
        canvas.worldCamera = Camera.main;
    }
}
