using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        gameManager = GameMan.instance;
        onShelves = GameObject.Find("OnShelves/value");
        offShelves = GameObject.Find("OffShelves/value");
        points = GameObject.Find("Points/value");
    }

    void Update()
    {
        onShelves.GetComponent<TextMeshProUGUI>().SetText(gameManager.itemsOnShelves.ToString());
        offShelves.GetComponent<TextMeshProUGUI>().SetText(gameManager.itemsOffShelves.ToString());
        points.GetComponent<TextMeshProUGUI>().SetText(gameManager.points.ToString());
    }
}
