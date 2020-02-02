using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    /*void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }*/

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
        points = itemsOnShelves * 5;

    }


    void Update()
    {
        if (Time.time >= nextTime)
        {
            points -= itemsOffShelves;
            nextTime += pointsTime;
            if (points <= 0)
            {
                Cursor.lockState = CursorLockMode.None;
                Debug.Log(points + " " + itemsOffShelves + " " + itemsOnShelves + " " + totalItems);
                SceneManager.LoadScene(3, LoadSceneMode.Single);
            }
        }
    }

    public void decrementPoints()
    {
        itemsOnShelves -= 1;
        itemsOffShelves += 1;
        //points -= 2 * itemsOffShelves;
    }
}

