using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlock : MonoBehaviour
{
    private PlayerMovement player;
    private bool canBeDistroyed = false;
    void Start()
    {
       player = FindObjectOfType<PlayerMovement>();
    }

    private void SpawnItem(int px, int py, int pickMultiplier)
    {
        string objName = this.gameObject.name;
        

        if (objName == "GrassBlockTamplate(Clone)")
        {
            canBeDistroyed = true;
            for (int i = 0; i < pickMultiplier; i++)
            {
                ItemWorld.SpawnItemWorld(new Vector3Int(px, py, 0), new Item { itemType = Item.ItemType.Dirt, amount = 1 });
            }
        }
        if (objName == "DirtBlockTamplate(Clone)")
        {
            canBeDistroyed = true;
            for (int i = 0; i < pickMultiplier; i++)
            {
                ItemWorld.SpawnItemWorld(new Vector3Int(px, py, 0), new Item { itemType = Item.ItemType.Dirt, amount = 1 });
            }
        }
        if (objName == "StoneBlockTamplate(Clone)")
        {
            canBeDistroyed = true;
            for (int i = 0; i < pickMultiplier; i++)
            {
                ItemWorld.SpawnItemWorld(new Vector3Int(px, py, 0), new Item { itemType = Item.ItemType.Stone, amount = 1 });
            }
        }
        if (objName == "CoalBlockTamplate(Clone)")
        {
            canBeDistroyed = true;
            for (int i = 0; i < pickMultiplier; i++)
            {
                ItemWorld.SpawnItemWorld(new Vector3Int(px, py, 0), new Item { itemType = Item.ItemType.Coal, amount = 1 });
            }
        }
        if (objName == "IronBlockTamplate(Clone)")
        {
            canBeDistroyed = true;
            for (int i = 0; i < pickMultiplier; i++)
            {
                ItemWorld.SpawnItemWorld(new Vector3Int(px, py, 0), new Item { itemType = Item.ItemType.Iron, amount = 1 });
            }
        }
        if (objName == "GoldBlockTamplate(Clone)")
        {
            canBeDistroyed = true;
            for (int i = 0; i < pickMultiplier; i++)
            {
                ItemWorld.SpawnItemWorld(new Vector3Int(px, py, 0), new Item { itemType = Item.ItemType.Gold, amount = 1 });
            }
        }
        if (objName == "DiamondBlockTamplate(Clone)")
        {
            canBeDistroyed = true;
            for (int i = 0; i < pickMultiplier; i++)
            {
                ItemWorld.SpawnItemWorld(new Vector3Int(px, py, 0), new Item { itemType = Item.ItemType.Diamond, amount = 1 });
            }
        }

        if (objName == "UnbrakebleBlockTamplate(Clone)")
        {
            canBeDistroyed = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            
            int px = player.coordXToDistroy;
            int py = player.coordYToDistroy;
            int pickMultiplier = player.pickMultiplier;
            if(this.gameObject.transform.position.x == px && this.gameObject.transform.position.y == py)
            {
                SpawnItem(px, py, pickMultiplier);
                if (canBeDistroyed)
                {
                    Destroy(gameObject);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            
            int px = player.coordXToDistroy;
            int py = player.coordYToDistroy;
            int pickMultiplier = player.pickMultiplier;
            if (this.gameObject.transform.position.x == px && this.gameObject.transform.position.y == py)
            {
                SpawnItem(px, py, pickMultiplier);
                if (canBeDistroyed)
                {
                    Destroy(gameObject);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            int px = player.coordXToDistroy;
            int py = player.coordYToDistroy;
            int pickMultiplier = player.pickMultiplier;
            if (this.gameObject.transform.position.x == px && this.gameObject.transform.position.y == py)
            {
                SpawnItem(px, py, pickMultiplier);
                if (canBeDistroyed)
                {
                    Destroy(gameObject);
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

            int px = player.coordXToDistroy;
            int py = player.coordYToDistroy;
            int pickMultiplier = player.pickMultiplier;
            if (this.gameObject.transform.position.x == px && this.gameObject.transform.position.y == py)
            {
                SpawnItem(px, py, pickMultiplier);
                if (canBeDistroyed)
                {
                    Destroy(gameObject);
                }
            }

        }
    }
}
