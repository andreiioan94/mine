using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    public event EventHandler OnItemListChanged;

    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();
    }

    public void AddItem(Item item)
    {
        if (item.IsStackble())
        {
            bool inInv = false;
            foreach (Item invItem in itemList)
            {
                if(invItem.itemType == item.itemType)
                {
                    inInv = true;
                    invItem.amount += item.amount;
                }
            }
            if (!inInv)
            {
                itemList.Add(item);
            }

        }
        else
        {
            itemList.Add(item);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem(Item item)
    {
            Item inInv = null;
            foreach (Item invItem in itemList)
            {
                if (invItem.itemType == item.itemType)
                {
                    inInv = invItem;
                    invItem.amount -= item.amount;
                }
            }
            if (inInv != null && inInv.amount <=0)
            {
                itemList.Remove(inInv);
            }

      
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}
