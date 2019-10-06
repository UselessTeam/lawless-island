using System;
using UnityEngine;

public class SelectableOption : ScriptableObject {
    public Sprite sprite;
    public new string name;
    public string description;
    public ItemList cost {
        get {
            if(_cost == null) {
                _cost = new ItemList(costForInspector);
            }
            return _cost;
        }
        set {
            _cost = value;
        }
    }
    private ItemList _cost;
    [SerializeField]
    private ItemStack[] costForInspector;
    [SerializeField]
    public IActionable onSelected;
}

public abstract class IActionable : MonoBehaviour{

    public abstract void Activate(SelectableOption option);
}