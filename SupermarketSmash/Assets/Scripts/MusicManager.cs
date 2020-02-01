using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    GameMan gameManager;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameMan>();
        AkSoundEngine.SetState("Happy_Hectic", "Happy_Hectic");
        AkSoundEngine.SetRTPCValue("Music_RTPC", 0);
        AkSoundEngine.PostEvent("Game_Music_Event", gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        AkSoundEngine.SetRTPCValue("Music_RTPC", gameManager.itemsOffShelves);
    }
}
