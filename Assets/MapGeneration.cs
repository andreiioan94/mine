using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    private GameObject Map;
    private Transform BlocksContainer;
    private Transform GrassBlockTamplate;
    private Transform InvisibleBlockTamplate;
    private Transform DirtBlockTamplate;
    private Transform StoneBlockTamplate;
    private Transform CoalBlockTamplate;
    private Transform IronBlockTamplate;
    private Transform GoldBlockTamplate;
    private Transform DiamondBlockTamplate;
    private Transform UnbrakebleBlockTamplate;

    

    void Start()
    {
        Map = GameObject.Find("Map");
        BlocksContainer = Map.transform;
        InvisibleBlockTamplate = Map.transform.GetChild(1);
        UnbrakebleBlockTamplate = Map.transform.GetChild(2);
        GrassBlockTamplate = Map.transform.GetChild(3);
        DirtBlockTamplate = Map.transform.GetChild(4);
        StoneBlockTamplate = Map.transform.GetChild(5);
        CoalBlockTamplate = Map.transform.GetChild(6);
        IronBlockTamplate = Map.transform.GetChild(7);
        GoldBlockTamplate = Map.transform.GetChild(8);
        DiamondBlockTamplate = Map.transform.GetChild(9);
        
        

        generateGrass();
        generateDirt();
        generateDirtStoneTransition();
        generateStoneAndOres();
        generateEndOfMine();
        generateInvisibleWall();
    }

    void generateGrass()
    {
        for (int i = -10; i <= 10; i++)
        {
            RectTransform rectTransform = Instantiate(GrassBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
            rectTransform.gameObject.SetActive(true);
            rectTransform.anchoredPosition = new Vector2(i, -4);
        }
    }

    void generateDirt()
    {
        for(int i = -5; i >= -6; i--)
        {
            for(int j = -10; j <= 10; j++)
            {
                RectTransform rectTransform = Instantiate(DirtBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                rectTransform.gameObject.SetActive(true);
                rectTransform.anchoredPosition = new Vector2(j, i);
            }
        }
    }

    void generateDirtStoneTransition()
    {
        var rand = new System.Random();

        for (int j = -10; j <= 10; j++)
        {
            int randomNumber = rand.Next(2);
            if (randomNumber == 0)
            {
                RectTransform rectTransform = Instantiate(DirtBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                rectTransform.gameObject.SetActive(true);
                rectTransform.anchoredPosition = new Vector2(j, -7);
            }
            else
            {
                RectTransform rectTransform = Instantiate(StoneBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                rectTransform.gameObject.SetActive(true);
                rectTransform.anchoredPosition = new Vector2(j, -7);
            }
        }
    }

    void generateStoneAndOres()
    {
        var rand = new System.Random();
        for (int i = -8; i >= -100; i--)
        {
            if(i <-9 && i >= -20)
            {
                for (int j = -10; j <= 10; j++)
                {
                    int randNumber = rand.Next(100);
                    if (randNumber <= 10)
                    {
                        RectTransform rectTransform = Instantiate(CoalBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                        rectTransform.gameObject.SetActive(true);
                        rectTransform.anchoredPosition = new Vector2(j, i);
                    }
                    else
                    {
                        RectTransform rectTransform = Instantiate(StoneBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                        rectTransform.gameObject.SetActive(true);
                        rectTransform.anchoredPosition = new Vector2(j, i);
                    }
                    
                }

            }
            else
            {
                if (i < -20 && i >= -30)
                {
                    for (int j = -10; j <= 10; j++)
                    {
                        int randNumber = rand.Next(100);
                        if (randNumber <= 20)
                        {
                            RectTransform rectTransform = Instantiate(CoalBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                            rectTransform.gameObject.SetActive(true);
                            rectTransform.anchoredPosition = new Vector2(j, i);
                        }
                        else
                        {
                            if (randNumber > 20 && randNumber <= 30)
                            {
                                RectTransform rectTransform = Instantiate(IronBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                                rectTransform.gameObject.SetActive(true);
                                rectTransform.anchoredPosition = new Vector2(j, i);
                            }
                            else
                            {
                                RectTransform rectTransform = Instantiate(StoneBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                                rectTransform.gameObject.SetActive(true);
                                rectTransform.anchoredPosition = new Vector2(j, i);
                            }
                        }
                    }
                }
                else
                {
                    if(i < -30 && i >= -50)
                    {
                        for (int j = -10; j <= 10; j++)
                        {
                            int randNumber = rand.Next(100);
                            if (randNumber <= 10)
                            {
                                RectTransform rectTransform = Instantiate(CoalBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                                rectTransform.gameObject.SetActive(true);
                                rectTransform.anchoredPosition = new Vector2(j, i);
                            }
                            else
                            {
                                if(randNumber > 10 && randNumber <= 40)
                                {
                                    RectTransform rectTransform = Instantiate(IronBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                                    rectTransform.gameObject.SetActive(true);
                                    rectTransform.anchoredPosition = new Vector2(j, i);
                                }
                                else
                                {
                                    RectTransform rectTransform = Instantiate(StoneBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                                    rectTransform.gameObject.SetActive(true);
                                    rectTransform.anchoredPosition = new Vector2(j, i);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (i < -50 && i >= -60)
                        {
                            for (int j = -10; j <= 10; j++)
                            {
                                int randNumber = rand.Next(100);
                                if (randNumber <= 1)
                                {
                                    RectTransform rectTransform = Instantiate(DiamondBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                                    rectTransform.gameObject.SetActive(true);
                                    rectTransform.anchoredPosition = new Vector2(j, i);
                                }
                                else
                                {
                                    if (randNumber > 1 && randNumber <= 10)
                                    {
                                        RectTransform rectTransform = Instantiate(IronBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                                        rectTransform.gameObject.SetActive(true);
                                        rectTransform.anchoredPosition = new Vector2(j, i);
                                    }
                                    else
                                    {
                                        if (randNumber > 10 && randNumber <= 20)
                                        {
                                            RectTransform rectTransform = Instantiate(GoldBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                                            rectTransform.gameObject.SetActive(true);
                                            rectTransform.anchoredPosition = new Vector2(j, i);
                                        }
                                        else
                                        {
                                            RectTransform rectTransform = Instantiate(StoneBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                                            rectTransform.gameObject.SetActive(true);
                                            rectTransform.anchoredPosition = new Vector2(j, i);
                                        }
                                           
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (i < -60 && i >= -70)
                            {
                                for (int j = -10; j <= 10; j++)
                                {
                                    int randNumber = rand.Next(100);
                                    if (randNumber <= 1)
                                    {
                                        RectTransform rectTransform = Instantiate(DiamondBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                                        rectTransform.gameObject.SetActive(true);
                                        rectTransform.anchoredPosition = new Vector2(j, i);
                                    }
                                    else
                                    {
                                        if (randNumber > 1 && randNumber <= 15)
                                        {
                                            RectTransform rectTransform = Instantiate(GoldBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                                            rectTransform.gameObject.SetActive(true);
                                            rectTransform.anchoredPosition = new Vector2(j, i);
                                        }
                                        else
                                        { 
                                            RectTransform rectTransform = Instantiate(StoneBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                                            rectTransform.gameObject.SetActive(true);
                                            rectTransform.anchoredPosition = new Vector2(j, i);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (i < -70 && i >= -100)
                                {
                                    for (int j = -10; j <= 10; j++)
                                    {
                                        int randNumber = rand.Next(100);
                                        if (randNumber <= 3)
                                        {
                                            RectTransform rectTransform = Instantiate(DiamondBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                                            rectTransform.gameObject.SetActive(true);
                                            rectTransform.anchoredPosition = new Vector2(j, i);
                                        }
                                        else
                                        {
                                            if(randNumber > 3 && randNumber <= 4)
                                            {
                                                RectTransform rectTransform = Instantiate(GoldBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                                                rectTransform.gameObject.SetActive(true);
                                                rectTransform.anchoredPosition = new Vector2(j, i);
                                            }
                                            else
                                            {
                                                if(randNumber > 4 && randNumber <= 5)
                                                {
                                                    RectTransform rectTransform = Instantiate(IronBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                                                    rectTransform.gameObject.SetActive(true);
                                                    rectTransform.anchoredPosition = new Vector2(j, i);
                                                }
                                                else
                                                {
                                                    RectTransform rectTransform = Instantiate(StoneBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                                                    rectTransform.gameObject.SetActive(true);
                                                    rectTransform.anchoredPosition = new Vector2(j, i);
                                                }
                                            }
                                            
                                        }
                                    }
                                }
                                else
                                {
                                    for (int j = -10; j <= 10; j++)
                                    {
                                        RectTransform rectTransform = Instantiate(StoneBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
                                        rectTransform.gameObject.SetActive(true);
                                        rectTransform.anchoredPosition = new Vector2(j, i);
                                    }
                                }
                            }
                            
                        }
                    }
                    
                }
            }
        }
    }


    void generateInvisibleWall()
    {
        for (int i = -10; i <= 10; i++)
        {
            RectTransform rectTransform = Instantiate(InvisibleBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
            rectTransform.gameObject.SetActive(true);
            rectTransform.anchoredPosition = new Vector2(i, 2);
        }
        for (int i = -10; i <= 10; i++)
        {
            RectTransform rectTransform = Instantiate(InvisibleBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
            rectTransform.gameObject.SetActive(true);
            rectTransform.anchoredPosition = new Vector2(i, -105);
        }
        for (int j = 2; j >= -105; j--)
        {
            RectTransform rectTransform = Instantiate(InvisibleBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
            rectTransform.gameObject.SetActive(true);
            rectTransform.anchoredPosition = new Vector2(-11, j);
        }
        for (int j = 2; j >= -105; j--)
        {
            RectTransform rectTransform = Instantiate(InvisibleBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
            rectTransform.gameObject.SetActive(true);
            rectTransform.anchoredPosition = new Vector2(11, j);
        }
    }

    void generateEndOfMine()
    {
        for (int i = -10; i <= 10; i++)
        {
            RectTransform rectTransform = Instantiate(UnbrakebleBlockTamplate, BlocksContainer).GetComponent<RectTransform>();
            rectTransform.gameObject.SetActive(true);
            rectTransform.anchoredPosition = new Vector2(i, -101);
        }
    }
}
