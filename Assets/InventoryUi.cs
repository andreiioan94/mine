using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUi : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTamplate;
    private Transform itemSlotSelected;
    public int inventorySlot;
    public int itemAmount;
    public string itemType;
    public bool canRemove = false;
    public bool canPlace = false;

    private void Awake()
    {
        inventorySlot = 1;
        //itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotContainer = this.gameObject.transform.GetChild(0).GetChild(2);
        //Debug.Log(itemSlotContainer);
        itemSlotTamplate = this.gameObject.transform.GetChild(0).GetChild(2).GetChild(0);
        //Debug.Log(itemSlotTamplate);
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;

        Refresh();
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        Refresh();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            inventorySlot = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            inventorySlot = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            inventorySlot = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            inventorySlot = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            inventorySlot = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            inventorySlot = 6;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            inventorySlot = 7;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            inventorySlot = 8;
        }
        if (inventorySlot > inventory.GetItemList().Count)
        {
            inventorySlot = 1;
        }

        foreach (Transform child in itemSlotContainer)
        {
            RectTransform itemSlot = child.GetComponent<RectTransform>();
            Image imageNormalBorder = itemSlot.Find("border").GetComponent<Image>();
            BorderList bordNormal = new BorderList { borderType = BorderList.BorderType.normalBorder };
            imageNormalBorder.sprite = bordNormal.GetSprite();
        }

        itemSlotSelected = this.gameObject.transform.GetChild(0).GetChild(2).GetChild(inventorySlot);
        RectTransform itemSlotRectTransform = itemSlotSelected.GetComponent<RectTransform>();
        Image image = itemSlotRectTransform.Find("border").GetComponent<Image>();
        BorderList bord = new BorderList { borderType = BorderList.BorderType.selectedBorder };
        image.sprite = bord.GetSprite();

        CanRemove();
        CanPlace();
        ItemInHand();
    }

    public void CanRemove()
    {
        itemSlotSelected = this.gameObject.transform.GetChild(0).GetChild(2).GetChild(inventorySlot);
        RectTransform itemSlotRectTransform = itemSlotSelected.GetComponent<RectTransform>();
        Image image = itemSlotRectTransform.Find("itemImg").GetComponent<Image>();
        Item validItem = new Item { itemType = Item.ItemType.Pick, amount = 1 };
        if (image.sprite == validItem.GetSprite())
        {
            canRemove = true;
        }
        else
        {
            canRemove = false;
        }
    }

    public void CanPlace()
    {
        itemSlotSelected = this.gameObject.transform.GetChild(0).GetChild(2).GetChild(inventorySlot);
        RectTransform itemSlotRectTransform = itemSlotSelected.GetComponent<RectTransform>();
        Image image = itemSlotRectTransform.Find("itemImg").GetComponent<Image>();
        Item validItem = new Item { itemType = Item.ItemType.Ladder, amount = 1 };
        if (image.sprite == validItem.GetSprite())
        {
            canPlace = true;
        }
        else
        {
            canPlace = false;
        }
    }

    //Adauga aici pentru fiecare item nou adaugat in joc
    public void ItemInHand()
    {
        itemSlotSelected = this.gameObject.transform.GetChild(0).GetChild(2).GetChild(inventorySlot);
        RectTransform itemSlotRectTransform = itemSlotSelected.GetComponent<RectTransform>();
        Image image = itemSlotRectTransform.Find("itemImg").GetComponent<Image>();
        
        Item pickItem = new Item { itemType = Item.ItemType.Pick, amount = 1 };
        if (image.sprite == pickItem.GetSprite())
        {
            itemType = "pick";
        }

        Item dirtItem = new Item { itemType = Item.ItemType.Dirt, amount = 1 };
        if (image.sprite == dirtItem.GetSprite())
        {
            itemType = "dirt";
        }

        Item sandItem = new Item { itemType = Item.ItemType.Sand, amount = 1 };
        if (image.sprite == sandItem.GetSprite())
        {
            itemType = "sand";
        }

        Item mudItem = new Item { itemType = Item.ItemType.Mud, amount = 1 };
        if (image.sprite == mudItem.GetSprite())
        {
            itemType = "mud";
        }

        Item coinItem = new Item { itemType = Item.ItemType.Coin, amount = 1 };
        if (image.sprite == coinItem.GetSprite())
        {
            itemType = "coin";
        }

        Item ladderItem = new Item { itemType = Item.ItemType.Ladder, amount = 1 };
        if (image.sprite == ladderItem.GetSprite())
        {
            itemType = "ladder";
        }

        TextMeshProUGUI uiText = itemSlotRectTransform.Find("amount").GetComponent<TextMeshProUGUI>();
        int.TryParse(uiText.text, out itemAmount);
    }

    public int getInventorySlot()
    {
        return inventorySlot;
    }

    private void Refresh()
    {
        foreach(Transform child in itemSlotContainer)
        {
            if (child == itemSlotTamplate) continue;
            Destroy(child.gameObject);
        }
        int x = 0;
        int y = 0;
        float xSize = 34.5522f;
        float ySize = 35.8354f;
        float xdif = -436.5487f;
        float ydif = 234.4f;
        foreach (Item item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemSlotTamplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);
            itemSlotRectTransform.anchoredPosition = new Vector2(x * xSize + xdif, y * ySize + ydif);
            Image image = itemSlotRectTransform.Find("itemImg").GetComponent<Image>();
            image.sprite = item.GetSprite();
            TextMeshProUGUI uiText = itemSlotRectTransform.Find("amount").GetComponent<TextMeshProUGUI>();
            if (item.amount > 1)
            {
                uiText.SetText(item.amount.ToString());
            }
            else
            {
                uiText.SetText("");
            }
            x++;
        }
    }
}
