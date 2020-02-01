using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    GameMan gameManager;
    GameObject onShelves;
    GameObject offShelves;
    GameObject points;


    void Start()
    {
        gameManager = FindObjectOfType<GameMan>();
        onShelves = GameObject.Find("OnShelves/value");
        offShelves = GameObject.Find("OffShelves/value");
        points = GameObject.Find("Points/value");
    }

    void Update()
    {
        onShelves.GetComponentInChildren<Text>().text = gameManager.itemsOnShelves.ToString();
        offShelves.GetComponentInChildren<Text>().text = gameManager.itemsOffShelves.ToString();
        points.GetComponentInChildren<Text>().text = gameManager.points.ToString();
    }
}
