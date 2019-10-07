using System;
using UnityEngine;
using UnityEngine.UI;

namespace Graphics.GUI {

    public class GUIHandler : Singleton<GUIHandler> {
        public Canvas canvas;

        public GUIPanel panel;
        [SerializeField]
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

        public void SelectTool(int toolId) {
            inventory.SelectTool(toolId);
        }
    }

}