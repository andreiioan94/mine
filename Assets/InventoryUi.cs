using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUi : MonoBehaviour
{
    private GameObject inventoryUi;
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
        inventoryUi = GameObject.Find("InventoryUI");
        itemSlotContainer = inventoryUi.transform.GetChild(0).GetChild(2);
        //Debug.Log(itemSlotContainer);
        itemSlotTamplate = inventoryUi.transform.GetChild(0).GetChild(2).GetChild(0);
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
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            inventorySlot = 9;
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
        Item validItem1 = new Item { itemType = Item.ItemType.PickLvL0, amount = 1 };
        
        Item validItem2 = new Item { itemType = Item.ItemType.PickLvL1, amount = 1 };
       
        Item validItem3 = new Item { itemType = Item.ItemType.PickLvL2, amount = 1 };
        
        Item validItem4 = new Item { itemType = Item.ItemType.PickLvL3, amount = 1 };
        
        Item validItem5 = new Item { itemType = Item.ItemType.PickLvL4, amount = 1 };

        if (image.sprite == validItem1.GetSprite() || image.sprite == validItem2.GetSprite() || image.sprite == validItem3.GetSprite() || image.sprite == validItem4.GetSprite() || image.sprite == validItem5.GetSprite())
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
        
        Item pickItem = new Item { itemType = Item.ItemType.PickLvL0, amount = 1 };
        if (image.sprite == pickItem.GetSprite())
        {
            itemType = "picklvl0";
        }
        pickItem = new Item { itemType = Item.ItemType.PickLvL1, amount = 1 };
        if (image.sprite == pickItem.GetSprite())
        {
            itemType = "picklvl1";
        }
        pickItem = new Item { itemType = Item.ItemType.PickLvL2, amount = 1 };
        if (image.sprite == pickItem.GetSprite())
        {
            itemType = "picklvl2";
        }
        pickItem = new Item { itemType = Item.ItemType.PickLvL3, amount = 1 };
        if (image.sprite == pickItem.GetSprite())
        {
            itemType = "picklvl3";
        }
        pickItem = new Item { itemType = Item.ItemType.PickLvL4, amount = 1 };
        if (image.sprite == pickItem.GetSprite())
        {
            itemType = "picklvl4";
        }

        Item dirtItem = new Item { itemType = Item.ItemType.Dirt, amount = 1 };
        if (image.sprite == dirtItem.GetSprite())
        {
            itemType = "dirt";
        }

        Item stoneItem = new Item { itemType = Item.ItemType.Stone, amount = 1 };
        if (image.sprite == stoneItem.GetSprite())
        {
            itemType = "stone";
        }

        Item coalItem = new Item { itemType = Item.ItemType.Coal, amount = 1 };
        if (image.sprite == coalItem.GetSprite())
        {
            itemType = "coal";
        }
        Item ironItem = new Item { itemType = Item.ItemType.Iron, amount = 1 };
        if (image.sprite == ironItem.GetSprite())
        {
            itemType = "iron";
        }
        Item goldItem = new Item { itemType = Item.ItemType.Gold, amount = 1 };
        if (image.sprite == goldItem.GetSprite())
        {
            itemType = "gold";
        }
        Item diamondItem = new Item { itemType = Item.ItemType.Diamond, amount = 1 };
        if (image.sprite == diamondItem.GetSprite())
        {
            itemType = "diamond";
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
        float xSize = 33f;
        float ySize = 33f;
        float xdif = -348.4f;
        float ydif = 204.0f;
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
