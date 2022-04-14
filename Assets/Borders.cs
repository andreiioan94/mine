using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    public static Borders Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public Sprite normalBorder;
    public Sprite selectedBorder;
}
