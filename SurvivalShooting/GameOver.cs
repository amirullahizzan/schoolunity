using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public AudioSource se;
    // Start is called before the first frame update
    void Start()
    {
        se = GetComponent<AudioSource>();
        se.PlayDelayed(1.5f);
    }


    float gameover_timer = 0;
    // Update is called once per frame
    void Update()
    {
        gameover_timer += Time.deltaTime;

        if (gameover_timer >= 12)
        {
            SceneManager.LoadScene(0);
        }
    }
}
