using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellShop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        int coinAmount = 0;
        if (itemWorld != null)
        {
            Item.ItemType type = itemWorld.GetItem().GetItemType();
            int itemAmount = itemWorld.GetItem().GetAmount();
            switch (type)
            {
                default:                    break;
                case Item.ItemType.Dirt:    coinAmount = 1; 
                                            itemWorld.DestroySelf(); 
                                            ItemWorld.SpawnItemWorld(new Vector3Int(-8, -3, 0), new Item { itemType = Item.ItemType.Coin, amount = coinAmount * itemAmount }); 
                                            break;
                case Item.ItemType.Stone:   coinAmount = 2; 
                                            itemWorld.DestroySelf(); 
                                            ItemWorld.SpawnItemWorld(new Vector3Int(-8, -2, 0), new Item { itemType = Item.ItemType.Coin, amount = coinAmount * itemAmount }); 
                                            break;
                case Item.ItemType.Coal:     coinAmount = 1; 
                                            itemWorld.DestroySelf(); 
                                            ItemWorld.SpawnItemWorld(new Vector3Int(-8, -2, 0), new Item { itemType = Item.ItemType.Coin, amount = coinAmount * itemAmount }); 
                                            break;
                case Item.ItemType.Iron:    coinAmount = 1;
                                            itemWorld.DestroySelf();
                                            ItemWorld.SpawnItemWorld(new Vector3Int(-8, -2, 0), new Item { itemType = Item.ItemType.Coin, amount = coinAmount * itemAmount });
                                            break;
                case Item.ItemType.Gold:    coinAmount = 1;
                                            itemWorld.DestroySelf();
                                            ItemWorld.SpawnItemWorld(new Vector3Int(-8, -2, 0), new Item { itemType = Item.ItemType.Coin, amount = coinAmount * itemAmount });
                                            break;
                case Item.ItemType.Diamond: coinAmount = 1;
                                            itemWorld.DestroySelf();
                                            ItemWorld.SpawnItemWorld(new Vector3Int(-8, -2, 0), new Item { itemType = Item.ItemType.Coin, amount = coinAmount * itemAmount });
                                            break;
            }
            
        }
    }
}
