using UnityEngine;
using UnityEngine.UI;

namespace Graphics.GUI {
    internal class GUIInventory : MonoBehaviour {

        [SerializeField]
        private GameObject guiInventoryItemPrefab = null;
        private GUIInventoryItem[] items = null;

        public const int SIZE = 6;

        void Awake() {
            items = new GUIInventoryItem[SIZE];
            for(int i = 0; i < SIZE; i++) {
                GameObject itemGameObject = Instantiate(guiInventoryItemPrefab, transform.position, Quaternion.identity, transform);
                itemGameObject.transform.localPosition = new Vector2(48*i - 120, 0);
                items[i] = itemGameObject.GetComponent<GUIInventoryItem>();
                items[i].show = false;
            }
        }

        void Start() {
            if(InventoryHandler.instance!= null) {
                InventoryHandler.instance.callback += UpdateGUI;
                UpdateGUI();
            }
        }

        void UpdateGUI() {
            for(int i = 0; i < InventoryHandler.inventoryItemTypeSize; i++) {
                int quantity = InventoryHandler.instance.GetQuantity((ItemType)i);
                if(quantity > 0) {
                    items[i].quantity.text = quantity.ToString();
                    items[i].show = true;
                } else {
                    items[i].show = false;
                }
            }
        }
    }
}