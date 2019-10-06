using UnityEngine;
using UnityEngine.UI;

namespace Graphics.GUI {
    internal class GUIInventoryItem : MonoBehaviour{

        [SerializeField]
        internal SpriteRenderer sprite = null;
        [SerializeField]
        internal Text quantity = null;

        internal bool show {
            get {
                return _show;
            }
            set {
                if(_show != value) {
                    _show = value;
                    sprite.enabled = value;
                    quantity.enabled = value;
                }
            }
        }
        private bool _show = true;

    }
}