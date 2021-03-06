﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Graphics.GUI {

    public class GUIPanel : MonoBehaviour {
        private int xMin = 0, xMax = 0, y = 0;
        private int? targetX = null, targetY = null;
        [SerializeField]
        private GUISelector selector = null;
        [SerializeField]
        private RectTransform subpanel = null;
        [SerializeField]
        private GUIItemList cost = null;
        [SerializeField]
        private GameObject selectablePrefab = null;

        internal int width = 0, height = 0;
        internal List<GUISelectable> selectables = null;

        private GUISelectable selected = null;

        public Text flavorText = null;

        public void Clean() {
            foreach(GUISelectable selectable in selectables) {
                Destroy(selectable.gameObject);
            }
            selectables = null;
        }

        public void Display(ICollection<SelectableOption> selectableOptions) {
            width = selectableOptions.Count;
            InternalDisplay(selectableOptions);
        }

        public void Display(SelectableOption[] selectableOptions) {
            width = selectableOptions.Length;
            InternalDisplay(selectableOptions);
        }

        private void InternalDisplay(IEnumerable<SelectableOption> selectableOptions) {
            int x = 0;
            if(selectables != null) {
                Clean();
            }
            selectables = new List<GUISelectable>();
            foreach (SelectableOption option in selectableOptions) {
                GameObject selectableGameObject = Instantiate(selectablePrefab, subpanel);
                RectTransform rect = (RectTransform)selectableGameObject.transform;
                rect.anchorMin = new Vector2((float)(x) / width, rect.anchorMin.y);
                rect.anchorMax = new Vector2((x + 1f) / width, rect.anchorMax.y);
                rect.offsetMin = new Vector2(12, 12);
                rect.offsetMax = new Vector2(-12, -12);
                GUISelectable selectable = selectableGameObject.GetComponent<GUISelectable>();
                selectable.xMin = x;
                selectable.xMax = x;
                selectable.y = 0;
                selectable.DisplayIcon(option);
                selectables.Add(selectable);
                x++;
            }
            xMin = 0; xMax = 0; y = 0;
            Reposition();
        }

        void Update() {
            if (Input.GetButtonDown("Left")) {
                targetX = xMin - 1;
            }
            if (Input.GetButtonDown("Right")) {
                targetX = xMax + 1;
            }
            if (Input.GetButtonDown("Up")) {
                targetY--;
            }
            if (Input.GetButtonDown("Down")) {
                targetY++;
            }
            if (targetX != null || targetY != null) {
                Reposition();
            }
            if (Input.GetButtonDown("Action")) {
                Activate();
            }
        }

        internal GUISelectable Find(int x, int y) {
            foreach (GUISelectable selectable in selectables) {
                if (selectable.IsIn(x, y)) {
                    return selectable;
                }
            }
            return null;
        }

        void Reposition() {
            int x = targetX.HasValue ? (width + targetX.Value) % width : xMin;
            int y = targetY.HasValue ? (height + targetY.Value) % height : this.y;

            GUISelectable selectable = Find(x, y);

            if (targetX != null) {
                xMin = selectable.xMin;
                xMax = selectable.xMax;
            }
            if (targetY != null) {
                y = selectable.y;
            }

            Select(selectable);

            targetX = null;
            targetY = null;
        }

        void Select(GUISelectable selectable) {
            selector.gameObject.SetActive(true);
            selected = selectable;
            cost.Display(selectable.associatedOption.cost);
            flavorText.text = selectable.associatedOption.description;
            selector.Select((RectTransform)selectable.transform);
        }

        void Activate() {
            if(selected.associatedOption.onSelected != null) {
                if (InventoryHandler.instance.IsEnough(selected.associatedOption.cost))
                {
                    InventoryHandler.instance.Remove(selected.associatedOption.cost);
                    selected.associatedOption.onSelected.Activate(selected.associatedOption);
                    GameHandler.instance.CloseGui();
                }
            }
		}
    }
}
