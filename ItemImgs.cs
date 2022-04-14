using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemImgs : MonoBehaviour
{
    public static ItemImgs Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Transform pfItemWorld;

    public Sprite sand;
    public Sprite dirt;
    public Sprite stone;
    public Sprite coin;
    public Sprite mud;
    public Sprite pick;
    public Sprite ladder;
}
