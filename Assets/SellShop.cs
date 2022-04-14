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
                case Item.ItemType.Dirt:    coinAmount = 2; 
                                            itemWorld.DestroySelf(); 
                                            ItemWorld.SpawnItemWorld(new Vector3Int(-8, -2, 0), new Item { itemType = Item.ItemType.Coin, amount = coinAmount * itemAmount }); 
                                            break;
                case Item.ItemType.Sand:    coinAmount = 1; 
                                            itemWorld.DestroySelf(); 
                                            ItemWorld.SpawnItemWorld(new Vector3Int(-8, -2, 0), new Item { itemType = Item.ItemType.Coin, amount = coinAmount * itemAmount }); 
                                            break;
                case Item.ItemType.Stone:   coinAmount = 5; 
                                            itemWorld.DestroySelf(); 
                                            ItemWorld.SpawnItemWorld(new Vector3Int(-8, -2, 0), new Item { itemType = Item.ItemType.Coin, amount = coinAmount * itemAmount }); 
                                            break;
                case Item.ItemType.Mud:     coinAmount = 3; 
                                            itemWorld.DestroySelf(); 
                                            ItemWorld.SpawnItemWorld(new Vector3Int(-8, -2, 0), new Item { itemType = Item.ItemType.Coin, amount = coinAmount * itemAmount }); 
                                            break;
            }
            
        }
    }
}
