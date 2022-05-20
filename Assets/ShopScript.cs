using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    private Transform canvas;
    public bool activate;

    void Start()
    {
        activate = false;
        canvas = this.gameObject.transform.GetChild(0);
    }

    void Update()
    {
        Show();
    }

    void Show()
    {
        if (activate)
        {
            Canvas cvs = canvas.GetComponent<Canvas>();
            cvs.gameObject.SetActive(true);
        }
        else
        {
            Canvas cvs = canvas.GetComponent<Canvas>();
            cvs.gameObject.SetActive(false);
        }
    }
}
