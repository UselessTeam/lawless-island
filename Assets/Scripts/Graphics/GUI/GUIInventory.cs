using System;
using UnityEngine;

namespace Graphics.GUI
{
    internal class GUIInventory : MonoBehaviour
    {
        private readonly static ItemType[] GENERAL_ITEM_TYPES = new ItemType[] {
            ItemType.Berry,
            ItemType.Coal,
            ItemType.Crab,
            ItemType.Flower,
            ItemType.Herb,
            ItemType.Medal,
            ItemType.Metal,
            ItemType.Mushroom,
            ItemType.Ore,
            ItemType.Shadow,
            ItemType.Stick,
            ItemType.Stone,
            ItemType.Torch,
            ItemType.Wood
        };
        private readonly static ItemType[] TOOLS_ITEM_TYPES = new ItemType[4] {
            ItemType.Sword,
            ItemType.Harpoon,
            ItemType.Axe,
            ItemType.Pickaxe
        };

        [SerializeField]
        private GameObject guiInventoryItemPrefab = null;
        private GUIInventoryItem[] items = null;
        private const int TOOLS_SIZE = 4;

        [SerializeField]
        private GUIInventoryItem[] tools = new GUIInventoryItem[TOOLS_SIZE];
        private int selectedTool = -1;
        protected GUIInventoryItem sword { get { return tools[0]; } }
        protected GUIInventoryItem harpoon { get { return tools[1]; } }
        protected GUIInventoryItem axe { get { return tools[2]; } }
        protected GUIInventoryItem pickaxe { get { return tools[3]; } }
        [SerializeField]
        private GUISelector selector = null;
        [SerializeField]
        private GUIItemList generalItemList = null;

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
            SelectTool(0);
        }

        void Start()
        {
            if (InventoryHandler.instance != null)
            {
                InventoryHandler.instance.callback += UpdateGUI;
                UpdateGUI();
            }
        }

        void UpdateGUI() {
            ItemList list = new ItemList();
            foreach(ItemType type in GENERAL_ITEM_TYPES) {
                int quantity = InventoryHandler.instance.GetQuantity(type);
                if(quantity > 0) {
                    list.Add(type, quantity);
                }
            }
            generalItemList.Display(list);
            for(int i = 0; i < TOOLS_SIZE; i++){
                tools[i].show = InventoryHandler.instance.IsEnough(TOOLS_ITEM_TYPES[i], 1);
            }
        }

        internal void SelectTool(int tool) {
            if(tool != selectedTool) {
                selector.gameObject.SetActive(true);
                selector.Select((RectTransform)tools[tool].transform);
                selectedTool = tool;
            }
        }
    }
}