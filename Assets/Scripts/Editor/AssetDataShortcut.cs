#if UNITY_EDITOR

using UnityEditor;

public static class AssetDataShortcut {
    [MenuItem("Assets/CreateTile")]
    public static void CreateTile() {
        ScriptableObjectUtility.CreateAsset<MapTile>();
    }

    [MenuItem("Assets/CreateSelectableOption")]
    public static void CreateSelectableOption() {
        ScriptableObjectUtility.CreateAsset<SelectableOption>();
    }
}
#endif
