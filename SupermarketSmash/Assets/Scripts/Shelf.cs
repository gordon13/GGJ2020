using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    public GameObject itemPrefab;

    private ShelfItemPlacement[] itemPlaces;

    // Start is called before the first frame update
    void Start()
    {
        itemPlaces = GetComponentsInChildren<ShelfItemPlacement>();
        foreach (ShelfItemPlacement p in itemPlaces)
        {
            GameObject item = Instantiate(itemPrefab, p.transform.position, p.transform.rotation);
        }
        Time.timeScale = 0;

    }

    // Update is called once per frame
    void Update()
    {
        foreach (ShelfItemPlacement p in itemPlaces)
        {
            
        }
    }
}
