using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyScore : MonoBehaviour
{
    Text scoreText;
    public int scorepoints = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    public void AddScore()
    {
        scorepoints+=100;
        scoreText.text = "Score : " + scorepoints.ToString();
        scoreText.fontSize ++;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.anyKeyDown)
        //{
        //    scorepoints+=100;
        //}
        //AddScore();
    }
}
