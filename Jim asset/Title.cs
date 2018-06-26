using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public static Title inst;
    public bool isStarted;
    public Transform pressT;
    public Menu[] menus;

    public Font thinF;
    public Font thickF;
    public GameObject arrowUp;
    public GameObject arrowDown;
    public GameObject arrowBack;


    public float menuSpeed;

    private void Awake()
    {
        inst = this;
    }

    // Use this for initialization
    void Start()
    {
        foreach (Menu m in menus)
        {
            m.gameObject.SetActive(false);
        }
        

        if (Data.inst.currLevel != 0)
        {
            menus[2].Show();
            for (int i = 0; i < Data.inst.currLevel; i++)
            {
                menus[2].Down();
            }

        }
        else
        {
            menus[0].Show();
        }
    }

}
