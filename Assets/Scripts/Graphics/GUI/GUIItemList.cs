using UnityEngine;

namespace Graphics.GUI {
    internal class GUIItemList : MonoBehaviour {

        [SerializeField]
        private GameObject guiInventoryItemPrefab = null;
        private GUIInventoryItem[] items = new GUIInventoryItem[0];

        public static int ICON_WIDTH = 48+16;

        public int size = 0;

        internal void Clean() {
            foreach(GUIInventoryItem item in items) {
                Destroy(item.gameObject);
            }
            items = new GUIInventoryItem[0];
        }

        internal void Display(ItemList itemList) {
            size = itemList.length;
            Clean();
            items = new GUIInventoryItem[size];
            for(int i = 0; i < size; i++) {
                GameObject itemGameObject = Instantiate(guiInventoryItemPrefab, transform.position, Quaternion.identity, transform);
                itemGameObject.transform.localPosition = new Vector2(ICON_WIDTH*i - ((size - 1)* ICON_WIDTH) / 2f, 0f);
                items[i] = itemGameObject.GetComponent<GUIInventoryItem>();
                items[i].show = true;
            }
            UpdateDisplay(itemList);
        }

        internal void UpdateDisplay(ItemList itemList) {
            int i = 0;
            foreach(ItemStack stack in itemList.ToArray()) {
                items[i].quantity.text = stack.amount.ToString();
                items[i].sprite.sprite = stack.type.GetSprite();
                items[i].show = true;
                i++;
            }
        }
    }
}