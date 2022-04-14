using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public enum ItemType
    {
        Sand,
        Dirt,
        Mud,
        Stone,
        Coin,
        Pick,
        Ladder
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Sand:     return ItemImgs.Instance.sand;
            case ItemType.Mud:      return ItemImgs.Instance.mud;
            case ItemType.Stone:    return ItemImgs.Instance.stone;
            case ItemType.Dirt:     return ItemImgs.Instance.dirt;
            case ItemType.Coin:     return ItemImgs.Instance.coin;
            case ItemType.Pick:     return ItemImgs.Instance.pick;
            case ItemType.Ladder:   return ItemImgs.Instance.ladder;
        }
    }

    public bool IsStackble()
    {
        switch (itemType)
        {
            default:
            case ItemType.Sand:     return true;
            case ItemType.Stone:    return true;
            case ItemType.Mud:      return true;
            case ItemType.Dirt:     return true;
            case ItemType.Coin:     return true;
            case ItemType.Ladder:   return true;
            case ItemType.Pick:     return false;
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
