using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fakeNPC : MonoBehaviour
{

    private GameManager gamemanager;
    private void Awake()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void EndAnimationTrigger()
    {
        gamemanager.SetNoSpook();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
