using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfItemPlacement : MonoBehaviour
{
    GameMan gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameMan>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider obj)
    {
        if (obj.GetComponent<ShelfItem>())
        {
        }
    }

    private void OnTriggerExit(Collider obj)
    {
        if (obj.GetComponent<ShelfItem>())
        {
            gameManager.decrementPoints();
        }
    }
}
