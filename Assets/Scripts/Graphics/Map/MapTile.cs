using UnityEngine;
using UnityEngine.Tilemaps;

public class MapTile : Tile {

    public Sprite[] sprites;
    public GameObject decorationGameObject;
    public float decorationProbability;

    public override void GetTileData(Vector3Int location, ITilemap tilemap, ref TileData tileData) {
        tileData.sprite = sprites[Random.Range(0,sprites.Length)];
        if(Random.Range(0f, 1f) < decorationProbability) {
            tileData.gameObject = decorationGameObject;
        }
        tileData.color = color;
    }
}