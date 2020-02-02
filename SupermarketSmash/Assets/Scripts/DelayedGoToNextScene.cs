using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayedGoToNextScene : MonoBehaviour
{
    
    void Start()
    {
        Debug.Log("delay go to next scene");
    }

    float i = 0;
    void Update()
    {
        i += Time.deltaTime;
        if (i >= 5)
        {
            Debug.Log("load next scene");
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
        
    }
}
