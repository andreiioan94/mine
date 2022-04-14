using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rbody;
    private Inventory inventory;
    public GameObject player;
    public bool isGrounded;
    private GameObject LCont;
    private Transform LadderContainer;
    private Transform LadderTamplate;

    [SerializeField] private InventoryUi inventoryui;

    void Start()
    {
        player = GameObject.Find("Player");
        rbody = GetComponent<Rigidbody2D>();

        LCont = GameObject.Find("LadderContainer");
        LadderContainer = LCont.transform;
        LadderTamplate = LCont.transform.GetChild(0);
        LadderTamplate = LadderContainer.transform.GetChild(0);

        //ItemWorld.SpawnItemWorld(new Vector3Int(0, -3, 0), new Item { itemType = Item.ItemType.Pick, amount = 1 });
        //ItemWorld.SpawnItemWorld(new Vector3Int(0, -3, 0), new Item { itemType = Item.ItemType.Coin, amount = 50 });
        inventory.AddItem(new Item { itemType = Item.ItemType.Pick, amount = 1 });
        inventory.AddItem(new Item { itemType = Item.ItemType.Coin, amount = 100 });
        inventory.AddItem(new Item { itemType = Item.ItemType.Ladder, amount = 10 });

    }

    void Awake()
    {
        inventory = new Inventory();
        
        inventoryui.SetInventory(inventory);
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
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
                case "ladder":  dItem = new Item { itemType = Item.ItemType.Ladder, amount = dAmount }; break;
                case "pick":    dItem = new Item { itemType = Item.ItemType.Pick, amount = dAmount };   break;
                case "mud":     dItem = new Item { itemType = Item.ItemType.Mud, amount = dAmount };    break;
                case "stone":   dItem = new Item { itemType = Item.ItemType.Stone, amount = dAmount };  break;
                case "dirt":    dItem = new Item { itemType = Item.ItemType.Dirt, amount = dAmount };   break;
                case "coin":    dItem = new Item { itemType = Item.ItemType.Coin, amount = dAmount };   break;
                case "sand":    dItem = new Item { itemType = Item.ItemType.Sand, amount = dAmount };   break;
            }
            inventory.RemoveItem(dItem);
            var px = Mathf.RoundToInt(player.transform.position.x);
            var py = Mathf.RoundToInt(player.transform.position.y);
            var dropPos = new Vector3Int(px-2, py, 0);
            ItemWorld.DropItem(dropPos, dItem);
            FindObjectOfType<InventoryUi>().inventorySlot = 1;
        }

        placeItem();
    }

}
