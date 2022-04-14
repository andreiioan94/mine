using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderList
{
    public enum BorderType
    {
        normalBorder,
        selectedBorder
    }

    public BorderType borderType;
    
    public Sprite GetSprite()
    {
        switch (borderType)
        {
            default:
            case BorderType.normalBorder:     return Borders.Instance.normalBorder;
            case BorderType.selectedBorder:   return Borders.Instance.selectedBorder;
        }
    }
}
