using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMan : MonoBehaviour
{
    public static GameMan instance = null;
    public int itemsOnShelves;
    public int itemsOffShelves;
    
    //private BoardManager boardScript;
    private ShelfItem[] items;
    private Shelf[] shelves;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        InitGame();
    }

    void InitGame()
    {
        shelves = FindObjectsOfType<Shelf>();
        foreach (var shelf in shelves)
        {
            shelf.Spawn();
        }

        items = FindObjectsOfType<ShelfItem>();
        foreach (var item in items)
        {
            item.disturbed = false;
        }
        itemsOnShelves = items.Length;
        itemsOffShelves = 0;
    }


    void Update()
    {

    }
}

