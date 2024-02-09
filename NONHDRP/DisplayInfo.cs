using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInfo : MonoBehaviour
{
    public Text sleepylevelText;
    public Text timerText;
    public GameManager gamemanager;
    
    public GameObject ingameuiGO;
    public GameObject mainmenuGO;
    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!gamemanager.isGameStart && gamemanager.isIntroStart)
        {
            mainmenuGO.SetActive(false);

            return;
        }

        if (gamemanager.isGameStart)
        {
            if (!ingameuiGO.gameObject.activeSelf)
            { ingameuiGO.SetActive(true); }
            sleepylevelText.text = "Sleepy Level : " + gamemanager.GetSleepyLevel().ToString() + " / "+ GameManager.MAX_SLEEPY_LEVEL;
            timerText.text = "0" + gamemanager.currentTime.ToString() + ":00"; //only displayed when not sleeping
        }

    }

}
