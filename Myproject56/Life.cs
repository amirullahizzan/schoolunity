using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    public int hp = 3;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    void Start()
    {

    }

    void Update()
    {
        switch (hp)
        {
            case 2:
                heart3.SetActive(false);
                break;
            case 1:
                heart2.SetActive(false);
                break;
            case 0:
                SceneManager.LoadScene(0);
                heart1.SetActive(false);
                break;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy")) //collision's gameobject
        {
            hp = hp - 1;
            
        }
        if (collision.gameObject.CompareTag("HPBox"))
        {
            switch (hp)
            {
                case 2:
                    heart3.SetActive(true);
                    break;
                case 1:
                    heart2.SetActive(true);
                    break;
            }
            
            Debug.Log(hp);
            hp++;
        }
    }
}
