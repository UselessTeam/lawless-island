using UnityEngine;

namespace Graphics.GUI
{
    internal class GUIInventory : MonoBehaviour
    {

        [SerializeField]
        private GameObject guiInventoryItemPrefab = null;
        private GUIInventoryItem[] items = null;
        private const int TOOLS_SIZE = 4;

        [SerializeField]
        private GUIInventoryItem[] tools = new GUIInventoryItem[TOOLS_SIZE];
        protected GUIInventoryItem sword { get { return tools[0]; } }
        protected GUIInventoryItem harpoon { get { return tools[1]; } }
        protected GUIInventoryItem axe { get { return tools[2]; } }
        protected GUIInventoryItem pickaxe { get { return tools[3]; } }
        public const int SIZE = 6;

        void Awake()
        {
            items = new GUIInventoryItem[InventoryHandler.inventoryItemTypeSize];
            for (int i = 0; i < InventoryHandler.inventoryItemTypeSize; i++)
            {
                GameObject itemGameObject = Instantiate(guiInventoryItemPrefab, transform.position, Quaternion.identity, transform);
                itemGameObject.transform.localPosition = new Vector2(48 * i - 120, 0);
                items[i] = itemGameObject.GetComponent<GUIInventoryItem>();
                items[i].show = false;
            }
        }

        void Start()
        {
            if (InventoryHandler.instance != null)
            {
                InventoryHandler.instance.callback += UpdateGUI;
                UpdateGUI();
            }
        }

        void UpdateGUI()
        {
            for (int i = 0; i < InventoryHandler.inventoryItemTypeSize; i++)
            {
                int quantity = InventoryHandler.instance.GetQuantity((ItemType)i);
                if (quantity > 0)
                {
                    items[i].quantity.text = quantity.ToString();
                    items[i].show = true;
                }
                else
                {
                    items[i].show = false;
                }
            }
        }
    }
}