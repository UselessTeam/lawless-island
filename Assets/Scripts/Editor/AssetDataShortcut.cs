#if UNITY_EDITOR

using UnityEditor;

public static class AssetDataShortcut {
    [MenuItem("Assets/CreateTile")]
    public static void CreateTile() {
        ScriptableObjectUtility.CreateAsset<MapTile>();
    }
}
#endif
