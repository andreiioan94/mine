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

    public Sprite dirt;
    public Sprite stone;
    public Sprite coal;
    public Sprite iron;
    public Sprite gold;
    public Sprite diamond;
    public Sprite coin;
    public Sprite mud;
    public Sprite picklvl0;
    public Sprite picklvl1;
    public Sprite picklvl2;
    public Sprite picklvl3;
    public Sprite picklvl4;
    public Sprite ladder;
}
