using UnityEngine;

public class MapTileDecoration : MonoBehaviour {

    public SpriteRenderer renderer = null;
    public Sprite[] possibleSprites = null;

    void Awake()
    {
        renderer.sprite = possibleSprites[Random.Range(0, possibleSprites.Length)];
    }

    void Start()
    {
        transform.Translate(new Vector2(0.125f * Random.Range(-4, 4), 0.125f * Random.Range(-4, 4)));
    }
}
