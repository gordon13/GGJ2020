using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{
    public void startGame()
    {
        Debug.Log("clicked start");        

    }



    // the image you want to fade, assign in inspector
    public RawImage img;

    public void QuitGame()
    {
        StartCoroutine(Quit());
    }

    public void LoadMenu()
    {
        StartCoroutine(FadeImage(false, 2f, 0));
    }

    public void StartLoading()
    {
        StartCoroutine(FadeImage(false, 2f, 1));
    }

    public void LoadScene()
    {
        StartCoroutine(FadeImage(false, 2f, 5)); // 2 is samplescene, 5 is improvedscene
    }

    public void LoadGameOverScene()
    {
        StartCoroutine(FadeImage(false, 2f, 3));
    }

    public void LoadWinScene()
    {
        StartCoroutine(FadeImage(false, 2f, 4));
    }

    IEnumerator FadeImage(bool fadeAway, float time, int levelIndex)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = time; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1,1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= time; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        SceneManager.LoadScene(levelIndex, LoadSceneMode.Single);
    }

    IEnumerator Quit()
    {
        // fade from opaque to transparent
        for (float i = 0; i <= 2; i += Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(0, 0, 0, i);
            yield return null;
        }
        Application.Quit();
    }
}