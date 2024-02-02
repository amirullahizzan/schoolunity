using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInfo : MonoBehaviour
{
    public Text sleepylevelText;
    public Text timerText;
    public GameManager gamemanager;
    // Start is called before the first frame update
    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        sleepylevelText.text = "Sleepy Level : " + gamemanager.GetSleepyLevel().ToString();
        timerText.text = gamemanager.currentTime.ToString(); //only displayed when not sleeping
    }
}
