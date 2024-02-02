using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject Camera;
    public GameObject FadeBox;
    CameraEventTrigger cameraEventTrigger;
    //public GameObject GameManagerGO;
    public GameManager gamemanager;
    public DisplayInfo displayinfo;
    Animator cameraAnimator;
    Animator fadeboxAnimator;

    void Awake()
    {
        cameraAnimator  = Camera.GetComponent<Animator>();
        fadeboxAnimator = FadeBox.GetComponent<Animator>();
        cameraEventTrigger = Camera.GetComponent<CameraEventTrigger>();
    }

    bool isKeyPressed = false;
    public bool isSleeping = true;

    private void Start()
    {
        //Tutorials
        //Debug.Log("TO PLAY, USE SOUND");
        //Debug.Log("Press to open eyes");
        //Debug.Log("Survive until 5 AM");
        //Debug.Log("you fell asleep because you are too tired...");
        //Debug.Log("Spam buttons to stop hallucinating!");
    }
    // Update is called once per frame
    void Update()
    {
        { cameraAnimator.SetBool("isSleeping", isSleeping); }
        { fadeboxAnimator.SetBool("isSleeping", isSleeping); }
        
        if (Input.anyKey)
        {
        isKeyPressed = true;
        
        }
        else
        {
        isKeyPressed = false;
        }

        UpdatePlayerState();
    }

 
    void UpdatePlayerState()
    {
        if(isKeyPressed)
        {
            Debug.Log("player is AWAKE");
            isSleeping = false;
            // hold all attacks?. no

        }
        else if(!isKeyPressed && cameraEventTrigger.isFullyFacingRoom)
        {
            Debug.Log("player is ZZZZ");
            isSleeping = true;
            displayinfo.timerText.enabled = false;
        }

        if (cameraEventTrigger.isFullyFacingRoom)
        {
            if (gamemanager.isAttacking) { return;}
             gamemanager.DeleteAllEnemy();
        }

    }
}
