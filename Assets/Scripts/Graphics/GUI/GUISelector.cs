using UnityEngine;

namespace Graphics.GUI {


    internal class GUISelector : MonoBehaviour {

        public RectTransform rectTransform = null;

        void Awake() {
            rectTransform = (RectTransform)transform;
        }

        public void Select(RectTransform selected) {
            rectTransform.anchorMin = selected.anchorMin;
            rectTransform.anchorMax = selected.anchorMax;
            rectTransform.offsetMin = selected.offsetMin;
            rectTransform.offsetMax = selected.offsetMax;
        }
    }

}