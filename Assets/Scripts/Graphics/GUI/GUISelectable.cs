using UnityEngine;
using UnityEngine.UI;

namespace Graphics.GUI {


    internal class GUISelectable : MonoBehaviour {
        internal int xMin, xMax, y;

        [SerializeField]
        internal SpriteRenderer spriteRenderer = null;
        [SerializeField]
        internal Text textName = null;

        internal SelectableOption associatedOption = null;

        internal bool IsIn(int x, int y) {
            if (xMin <= x && x <= xMax && this.y == y) {
                return true;
            }
            return false;
        }

        internal void DisplayIcon(SelectableOption option) {
            spriteRenderer.sprite = option.sprite;
            textName.text = option.name;
            associatedOption = option;
        }
    }

}