using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rbody;
    public Inventory inventory;
    public GameObject player;
    public bool isGrounded;
    private GameObject LCont;
    private Transform LadderContainer;
    private Transform LadderTamplate;
    private GameObject Map;
    private Transform BlankBlockTamplate;
    private Transform BlocksContainer;

    public int coordXToDistroy = -1;
    public int coordYToDistroy = -1;
    public int pickMultiplier = 1;

    [SerializeField] private InventoryUi inventoryui;

    void Start()
    {
        player = GameObject.Find("Player");
        rbody = GetComponent<Rigidbody2D>();

        LCont = GameObject.Find("LadderContainer");
        LadderContainer = LCont.transform;
        LadderTamplate = LCont.transform.GetChild(0);
        LadderTamplate = LadderContainer.transform.GetChild(0);


        Map = GameObject.Find("Map");
        BlocksContainer = Map.transform;
        BlankBlockTamplate = Map.transform.GetChild(0);
        

        //ItemWorld.SpawnItemWorld(new Vector3Int(0, -3, 0), new Item { itemType = Item.ItemType.Pick, amount = 1 });
        //ItemWorld.SpawnItemWorld(new Vector3Int(0, -3, 0), new Item { itemType = Item.ItemType.Coin, amount = 50 });
        inventory.AddItem(new Item { itemType = Item.ItemType.PickLvL0, amount = 1 });
        inventory.AddItem(new Item { itemType = Item.ItemType.Coin, amount = 800 });
        inventory.AddItem(new Item { itemType = Item.ItemType.Ladder, amount = 10 });
        
        /*inventory.AddItem(new Item { itemType = Item.ItemType.PickLvL1, amount = 1 });
        inventory.AddItem(new Item { itemType = Item.ItemType.PickLvL2, amount = 1 });
        inventory.AddItem(new Item { itemType = Item.ItemType.PickLvL3, amount = 1 });
        inventory.AddItem(new Item { itemType = Item.ItemType.PickLvL4, amount = 1 });
        inventory.AddItem(new Item { itemType = Item.ItemType.PickLvL0, amount = 1 });
        inventory.AddItem(new Item { itemType = Item.ItemType.PickLvL0, amount = 1 });*/

    }

    void Awake()
    {
        inventory = new Inventory();
        
        inventoryui.SetInventory(inventory);
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        Item item;
        
        if (inventory.GetItemList().Count < 9)
        {
            if (itemWorld != null)
            {
                item = itemWorld.GetItem();
                inventory.AddItem(item);
                itemWorld.DestroySelf();
            }
        }
        else
        {
            if (inventory.GetItemList().Count == 9)
            {
                if (itemWorld != null)
                {
                    item = itemWorld.GetItem();
                    if (item.IsStackble())
                    {
                        foreach (Item item2 in inventory.GetItemList())
                        {
                            if (item.itemType == item2.itemType)
                            {
                                inventory.AddItem(itemWorld.GetItem());
                                itemWorld.DestroySelf();
                            }
                        }
                    }
                }
            }
        }
    }

    public InventoryUi GetInventoryUi()
    {
        return inventoryui;
    }

    public void placeItem()
    {
        if (FindObjectOfType<InventoryUi>().canPlace == true)
        {
            
            var px = Mathf.RoundToInt(player.transform.position.x);
            var py = Mathf.RoundToInt(player.transform.position.y);

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                inventory.RemoveItem(new Item { itemType = Item.ItemType.Ladder, amount = 1 });
                py = py + 2;
                px = px - 1;
                RectTransform LadderRectTransform = Instantiate(LadderTamplate, LadderContainer).GetComponent<RectTransform>();
                LadderRectTransform.gameObject.SetActive(true);
                LadderRectTransform.anchoredPosition = new Vector2(px, py);
            }
        }
    }

    void distroyBlock()
    {
        
        switch (FindObjectOfType<InventoryUi>().itemType)
        {
            case "picklvl0": pickMultiplier = 1; break;
            case "picklvl1": pickMultiplier = 2; break;
            case "picklvl2": pickMultiplier = 3; break;
            case "picklvl3": pickMultiplier = 4; break;
            case "picklvl4": pickMultiplier = 5; break;
            default: pickMultiplier = 1; break;
        }
        if (FindObjectOfType<InventoryUi>().canRemove == true)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                int px = Mathf.RoundToInt(player.transform.position.x);
                int py = Mathf.RoundToInt(player.transform.position.y) - 1;
                coordXToDistroy = px;
                coordYToDistroy = py;
                

                RectTransform rectTransform = Instantiate(BlankBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                rectTransform.gameObject.SetActive(true);
                rectTransform.anchoredPosition = new Vector2(px, py);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                int px = Mathf.RoundToInt(player.transform.position.x)+1;
                int py = Mathf.RoundToInt(player.transform.position.y);
                coordXToDistroy = px;
                coordYToDistroy = py;

                RectTransform rectTransform = Instantiate(BlankBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                rectTransform.gameObject.SetActive(true);
                rectTransform.anchoredPosition = new Vector2(px, py);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                int px = Mathf.RoundToInt(player.transform.position.x) - 1;
                int py = Mathf.RoundToInt(player.transform.position.y);
                coordXToDistroy = px;
                coordYToDistroy = py;

                RectTransform rectTransform = Instantiate(BlankBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                rectTransform.gameObject.SetActive(true);
                rectTransform.anchoredPosition = new Vector2(px, py);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                int px = Mathf.RoundToInt(player.transform.position.x);
                int py = Mathf.RoundToInt(player.transform.position.y)+1;
                coordXToDistroy = px;
                coordYToDistroy = py;

                RectTransform rectTransform = Instantiate(BlankBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                rectTransform.gameObject.SetActive(true);
                rectTransform.anchoredPosition = new Vector2(px, py);
            }
        }
    }


    void Update()
    {
        transform.rotation = Quaternion.identity;
        float directionX = Input.GetAxis("Horizontal");
        rbody.velocity = new Vector2(directionX * 5f, rbody.velocity.y);

        if (Input.GetKeyDown("space"))
        {
            rbody.velocity = new Vector3(0, 5f, 0);
            isGrounded = false;
        }

        if (Input.GetKeyDown("q"))
        {
            int dAmount = FindObjectOfType<InventoryUi>().itemAmount;
            if (dAmount < 1)
            {
                dAmount = 1;
            }
            string itemType = FindObjectOfType<InventoryUi>().itemType;
            Item dItem;
            switch (itemType)
            {
                default:
                case "ladder":      dItem = new Item { itemType = Item.ItemType.Ladder, amount = dAmount }; break;
                case "picklvl0":    dItem = new Item { itemType = Item.ItemType.PickLvL0, amount = dAmount }; break;
                case "picklvl1":    dItem = new Item { itemType = Item.ItemType.PickLvL1, amount = dAmount }; break;
                case "picklvl2":    dItem = new Item { itemType = Item.ItemType.PickLvL2, amount = dAmount }; break;
                case "picklvl3":    dItem = new Item { itemType = Item.ItemType.PickLvL3, amount = dAmount }; break;
                case "picklvl4":    dItem = new Item { itemType = Item.ItemType.PickLvL4, amount = dAmount }; break;
                case "dirt":        dItem = new Item { itemType = Item.ItemType.Dirt, amount = dAmount }; break;
                case "stone":       dItem = new Item { itemType = Item.ItemType.Stone, amount = dAmount };  break;
                case "coal":        dItem = new Item { itemType = Item.ItemType.Coal, amount = dAmount }; break;
                case "iron":        dItem = new Item { itemType = Item.ItemType.Iron, amount = dAmount }; break;
                case "gold":        dItem = new Item { itemType = Item.ItemType.Gold, amount = dAmount }; break;
                case "diamond":     dItem = new Item { itemType = Item.ItemType.Diamond, amount = dAmount }; break;
                case "coin":        dItem = new Item { itemType = Item.ItemType.Coin, amount = dAmount };   break;
            }
            inventory.RemoveItem(dItem);
            var px = Mathf.RoundToInt(player.transform.position.x);
            var py = Mathf.RoundToInt(player.transform.position.y);
            var dropPos = new Vector3Int(px-1, py, 0);
            ItemWorld.DropItem(dropPos, dItem);
            FindObjectOfType<InventoryUi>().inventorySlot = 1;
        }
        distroyBlock();
        placeItem();
    }

}
