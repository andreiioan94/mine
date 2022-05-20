using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public enum ItemType
    {
        Dirt,
        Stone,
        Coal,
        Iron,
        Gold,
        Diamond,
        Coin,
        PickLvL0,
        PickLvL1,
        PickLvL2,
        PickLvL3,
        PickLvL4,
        Ladder
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Dirt:     return ItemImgs.Instance.dirt;
            case ItemType.Stone:    return ItemImgs.Instance.stone;
            case ItemType.Coal:     return ItemImgs.Instance.coal;
            case ItemType.Iron:     return ItemImgs.Instance.iron;
            case ItemType.Gold:     return ItemImgs.Instance.gold;
            case ItemType.Diamond:  return ItemImgs.Instance.diamond;
            case ItemType.Coin:     return ItemImgs.Instance.coin;
            case ItemType.PickLvL0: return ItemImgs.Instance.picklvl0;
            case ItemType.PickLvL1: return ItemImgs.Instance.picklvl1;
            case ItemType.PickLvL2: return ItemImgs.Instance.picklvl2;
            case ItemType.PickLvL3: return ItemImgs.Instance.picklvl3;
            case ItemType.PickLvL4: return ItemImgs.Instance.picklvl4;
            case ItemType.Ladder:   return ItemImgs.Instance.ladder;
        }
    }

    public bool IsStackble()
    {
        switch (itemType)
        {
            default:
            case ItemType.Dirt:     return true;
            case ItemType.Stone:    return true;
            case ItemType.Coal:     return true;
            case ItemType.Iron:     return true;
            case ItemType.Gold:     return true;
            case ItemType.Diamond:  return true;
            case ItemType.Coin:     return true;
            case ItemType.Ladder:   return true;
            case ItemType.PickLvL0: return false;
            case ItemType.PickLvL1: return false;
            case ItemType.PickLvL2: return false;
            case ItemType.PickLvL3: return false;
            case ItemType.PickLvL4: return false;
        }
    }

    public ItemType GetItemType()
    {
        return itemType;
    }

    public int GetAmount()
    {
        return amount;
    }
}
