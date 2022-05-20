using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemShopScript : MonoBehaviour
{
    PlayerMovement player;
    Inventory inventory;
    GameObject button;
    GameObject text;
    Text coinAmountText;
    
    void Awake()
    {
        player = FindObjectOfType<PlayerMovement>();
        button = this.transform.Find("Button").gameObject;
        text = this.transform.Find("Amount").gameObject;
        coinAmountText = text.GetComponent<Text>();
    }
    void Start()
    {
        
    }

    void buttonColor()
    {
        inventory = player.inventory;
        int coinAmont = 0;
        foreach (Item item in inventory.GetItemList())
        {
            if (item.itemType == Item.ItemType.Coin)
            {
                coinAmont = item.amount;
            }
        }
        int coinBmont;
        int.TryParse(coinAmountText.text, out coinBmont);
        if (coinAmont >= coinBmont)
        {
            Image image = button.GetComponent<Image>();
            image.color = new Color32(7, 164, 6, 100);
        }
        else
        {
            Image image = button.GetComponent<Image>();
            image.color = new Color32(255, 0, 0, 100);
        }
    }
    // Update is called once per frame
    void Update()
    {
        buttonColor();
    }
}
