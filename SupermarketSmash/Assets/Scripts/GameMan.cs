using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMan : MonoBehaviour
{
    public static GameMan instance = null;
    public int totalItems;
    public int itemsOnShelves;
    public int itemsOffShelves;
    public int points;
    public int pointsTime = 1;

    //private BoardManager boardScript;
    private ShelfItem[] items;
    private Shelf[] shelves;
    float nextTime = 0;

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

        items = FindObjectsOfType<ShelfItem>();
        totalItems = items.Length;
        foreach (var item in items)
        {
            item.disturbed = false;
        }
        itemsOnShelves = items.Length;
        itemsOffShelves = 0;

        //calculate initial points
        points = itemsOnShelves * 10;
    }


    void Update()
    {
        if (Time.time >= nextTime)
        {
            points -= 1;
            nextTime += pointsTime;
        }
    }

    public void decrementPoints()
    {
        itemsOnShelves -= 1;
        itemsOffShelves += 1;
        points -= 2 * itemsOffShelves;
    }
}

