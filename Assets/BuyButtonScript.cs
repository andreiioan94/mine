using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class BuyButtonScript : MonoBehaviour
{
    GameObject player;
    GameObject button;
    Inventory inventory;
    GameObject parent;
    GameObject text;
    GameObject itemImgObj;
    Text coinAmountText;
    GameObject quantity;

    void Start()
    {

        gameObject.GetComponent<Button>().onClick.AddListener(TaskOnClick);
        player = GameObject.Find("Player");
        button = this.gameObject;
        parent = this.transform.parent.gameObject;
        text = parent.transform.Find("Amount").gameObject;
        itemImgObj = parent.transform.Find("ItemImage").gameObject;
        quantity = parent.transform.Find("Quantity").gameObject;
        coinAmountText = text.GetComponent<Text>();
        
    }

    public void buy()
    {
        inventory = FindObjectOfType<PlayerMovement>().inventory;
        foreach (Item item in inventory.GetItemList())
        {
            if (item.itemType == Item.ItemType.Coin)
            {  
                int coinAmont;
                int.TryParse(coinAmountText.text, out coinAmont);
                if(item.amount>= coinAmont)
                {
                    item.amount = item.amount - coinAmont;
                    spawnItem();
                }
            }
        }
    }

    void spawnItem()
    {
        int itemsToAdd;
        int.TryParse(quantity.GetComponent<Text>().text, out itemsToAdd);
        Image image = itemImgObj.GetComponent<Image>();
        var itemName = image.sprite.name;
        switch (itemName)
        {
            default: break;
            case "shoppicklvl1":    
                inventory.AddItem( new Item { itemType = Item.ItemType.PickLvL1, amount = itemsToAdd });
                break;
            case "shoppicklvl2":
                inventory.AddItem(new Item { itemType = Item.ItemType.PickLvL2, amount = itemsToAdd });
                break;
            case "shoppicklvl3":
                inventory.AddItem(new Item { itemType = Item.ItemType.PickLvL3, amount = itemsToAdd });
                break;
            case "shoppicklvl4":
                inventory.AddItem(new Item { itemType = Item.ItemType.PickLvL4, amount = itemsToAdd });
                break;
            case "shopladder":
                inventory.AddItem(new Item { itemType = Item.ItemType.Ladder, amount = itemsToAdd });
                break;
        }
    }
    public void TaskOnClick()
    {
        Debug.Log("clicked");
        buy();
    }
}
