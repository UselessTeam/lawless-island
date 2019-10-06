using UnityEngine;

namespace Graphics.GUI {

    public class GUI : MonoBehaviour {
        public Canvas canvas;

        void Start() {
            canvas.worldCamera = Camera.main;
        }


        public void OpenPanel() {

        }
    }

}