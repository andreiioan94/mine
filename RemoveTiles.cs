using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Unity.Mathematics;

public class RemoveTiles : MonoBehaviour
{
    public Tilemap blocks;
    public GameObject player;
    public GameObject tileObj;
   
    void Start()
    {
        player = GameObject.Find("Player");
        blocks = GetComponent<Tilemap>();
    }


    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<InventoryUi>().canRemove == true)
        {
            var px = Mathf.RoundToInt(player.transform.position.x);
            var py = Mathf.RoundToInt(player.transform.position.y);

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                bool spawn = false;
                py = py - 2;
                px = px - 1;
                var tilePos = new Vector3Int(px, py, 0);
                if (blocks.GetTile(tilePos) != null)
                {
                    spawn = true;
                    blocks.SetTile(tilePos, null);
                }
                if (spawn)
                {
                    py = py + 2;
                    px = px + 1;
                    if (py >= -6 && py < -2)
                    {
                        ItemWorld.SpawnItemWorld(new Vector3Int(px, py - 1, 0), new Item { itemType = Item.ItemType.Sand, amount = 1 });
                    }
                    if (py < -6 && py >= -9)
                    {
                        ItemWorld.SpawnItemWorld(new Vector3Int(px, py - 1, 0), new Item { itemType = Item.ItemType.Dirt, amount = 1 });
                    }
                    if (py >= -14 && py < -9)
                    {
                        ItemWorld.SpawnItemWorld(new Vector3Int(px, py - 1, 0), new Item { itemType = Item.ItemType.Mud, amount = 1 });
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                bool spawn = false;
                py = py - 1;
                //px = px;
                var tilePos = new Vector3Int(px, py, 0);
                if (blocks.GetTile(tilePos) != null)
                {
                    spawn = true;
                    blocks.SetTile(tilePos, null);
                }
                if (spawn)
                {
                    py = py + 2;
                    px = px + 1;
                    if (py >= -6 && py < -2)
                    {
                        ItemWorld.SpawnItemWorld(new Vector3Int(px, py - 1, 0), new Item { itemType = Item.ItemType.Sand, amount = 1 });
                    }
                    if (py < -6 && py >= -9)
                    {
                        ItemWorld.SpawnItemWorld(new Vector3Int(px, py - 1, 0), new Item { itemType = Item.ItemType.Dirt, amount = 1 });
                    }
                    if (py >= -14 && py < -9)
                    {
                        ItemWorld.SpawnItemWorld(new Vector3Int(px, py - 1, 0), new Item { itemType = Item.ItemType.Mud, amount = 1 });
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                bool spawn = false;
                py = py - 1;
                px = px - 2;
                var tilePos = new Vector3Int(px, py, 0);
                if (blocks.GetTile(tilePos) != null)
                {
                    spawn = true;
                    blocks.SetTile(tilePos, null);
                }
                if (spawn)
                {
                    py = py + 2;
                    px = px + 1;
                    if (py >= -6 && py < -2)
                    {
                        ItemWorld.SpawnItemWorld(new Vector3Int(px, py - 1, 0), new Item { itemType = Item.ItemType.Sand, amount = 1 });
                    }
                    if (py < -6 && py >= -9)
                    {
                        ItemWorld.SpawnItemWorld(new Vector3Int(px, py - 1, 0), new Item { itemType = Item.ItemType.Dirt, amount = 1 });
                    }
                    if (py >= -14 && py < -9)
                    {
                        ItemWorld.SpawnItemWorld(new Vector3Int(px, py - 1, 0), new Item { itemType = Item.ItemType.Mud, amount = 1 });
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                bool spawn = false;
                //py = py;
                px = px - 1;
                var tilePos = new Vector3Int(px, py, 0);
                if (blocks.GetTile(tilePos) != null)
                {
                    spawn = true;
                    blocks.SetTile(tilePos, null);
                }
                if (spawn)
                {
                    py = py + 2;
                    px = px + 1;
                    if (py >= -6 && py < -2)
                    {
                        ItemWorld.SpawnItemWorld(new Vector3Int(px, py - 1, 0), new Item { itemType = Item.ItemType.Sand, amount = 1 });
                    }
                    if (py < -6 && py >= -9)
                    {
                        ItemWorld.SpawnItemWorld(new Vector3Int(px, py - 1, 0), new Item { itemType = Item.ItemType.Dirt, amount = 1 });
                    }
                    if (py >= -14 && py < -9)
                    {
                        ItemWorld.SpawnItemWorld(new Vector3Int(px, py - 1, 0), new Item { itemType = Item.ItemType.Mud, amount = 1 });
                    }
                }
            }
        }
    }
}
