using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUpdate : MonoBehaviour
{
    public GameMan gm;
    public float scale;
    public float width;
    GameObject theBar;
    // Start is called before the first frame update
    void Start()
    {
        scale = 1;
        width = 100;
        gm = GameObject.FindObjectOfType<GameMan>();
        theBar = GameObject.FindObjectOfType<HealthBarUpdate>().gameObject;
        Debug.Log("Test");
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.points >= 0)
        {
            scale = ((float)gm.points / (5 * (float)gm.totalItems));
        }
        //Debug.Log(scale);
        
        var theBarRectTransform = theBar.transform as RectTransform;
        theBarRectTransform.sizeDelta = new Vector2(scale*width, theBarRectTransform.sizeDelta.y);
    }
}
