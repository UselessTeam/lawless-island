using UnityEngine;
using UnityEngine.UI;

public class CameraScript : Singleton<CameraScript>
{
    public new Camera camera = null;

    public static Vector2 position = Vector2.zero;

    public static readonly int PPU = 16;
    private const int FACTOR = 3;

    private int cachedHeight = -1;
    private int cachedWidth = -1;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        if(true || cachedWidth != Screen.width || cachedHeight != Screen.height) {
            int desiredScreenHeight = 2 * (Screen.height / 2);
            int desiredScreenWidth = 2 * (Screen.width / 2);

            cachedHeight = desiredScreenHeight;
            cachedWidth = desiredScreenWidth;

            Screen.SetResolution(desiredScreenWidth, desiredScreenHeight, Screen.fullScreenMode);
            camera.orthographicSize = desiredScreenHeight / (2f * PPU * FACTOR);
        }
        camera.transform.position = new Vector3(Mathf.Round(PPU * position.x)/PPU, Mathf.Round(PPU * position.y)/PPU, -10f);
    }
}
