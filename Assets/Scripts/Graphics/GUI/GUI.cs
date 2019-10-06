using UnityEngine;
using UnityEngine.UI;

namespace Graphics.GUI {

    public class GUI : Singleton<GUI> {
        public Canvas canvas;

        public GUIPanel panel;
        internal GUIInventory inventory;
        public Text debugText;

        void Start() {
            canvas.worldCamera = Camera.main;
        }

        public GUIPanel OpenPanel() {
            panel.gameObject.SetActive(true);
            return panel;
        }

        public void Close() {
            panel.Clean();
            panel.gameObject.SetActive(false);
        }
    }

}