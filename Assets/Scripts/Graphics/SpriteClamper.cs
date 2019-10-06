using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteClamper : MonoBehaviour
{
    int PPU;
    // Start is called before the first frame update
    void Start()
    {
        PPU = CameraScript.PPU;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = ClampXY(transform.parent.position) - transform.parent.position;
    }


    public Vector3 ClampXY(Vector3 vector)
    {
        float x = Mathf.Round(vector.x * PPU);
        float y = Mathf.Round(vector.y * PPU);
        return new Vector3(x / PPU, y / PPU, vector.z);
    }
}
