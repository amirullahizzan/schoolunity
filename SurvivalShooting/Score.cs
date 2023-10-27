using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text text;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {   
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //text.text += score;
        //text.text = "Score : " + score;
    }


    public void AddScore(int scorevalue)
    {
         score+= scorevalue;
        // Cannot use this because need string. text.text = score;
        text.text = "Score : " + score;
        //text.text =  score.ToString();
    }
}
