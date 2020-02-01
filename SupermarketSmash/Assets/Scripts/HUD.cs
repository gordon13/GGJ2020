using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    GameMan gameManager;
    GameObject onShelves;
    GameObject offShelves;
    
    
    void Start()
    {
        gameManager = FindObjectOfType<GameMan>();
        onShelves = GameObject.Find("OnShelves/value");
        offShelves = GameObject.Find("OffShelves/value");
    }

    void Update()
    {
        onShelves.GetComponentInChildren<Text>().text = gameManager.itemsOnShelves.ToString();
        offShelves.GetComponentInChildren<Text>().text = gameManager.itemsOffShelves.ToString();
    }
}
