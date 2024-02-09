using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject Camera;
    public GameObject fadeBoxGO;
    CameraEventTrigger cameraEventTrigger;
    //public GameObject GameManagerGO;
    public GameManager gamemanager;
    public DisplayInfo displayinfo;
    public Animator cameraAnimator;

    void Awake()
    {
        cameraAnimator = Camera.GetComponent<Animator>();
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

        //Debug.Log("You are locked!. Spam buttons to stare the demon down!"); //gives lock and slight hint sound
    }
    // Update is called once per frame

    void Update()
    {
        //TODO add rustling sounds

        if (Input.anyKey)
        {
            isKeyPressed = true;
        }
        else
        {
            isKeyPressed = false;
        }

        if (!gamemanager.isGameStart)
        {
            if (isKeyPressed && !gamemanager.isIntroStart)
            {
                gamemanager.isIntroStart = true;
                { cameraAnimator.SetBool("isIntroStart", gamemanager.isIntroStart); }
            }
            //Set isGameStart = true on animation;
            return;
        }

        cameraAnimator.SetBool("isSleeping", isSleeping);
        if (fadeBoxGO)
        {
            Animator fadeboxAnimator = fadeBoxGO.GetComponent<Animator>();
            fadeboxAnimator.SetBool("isSleeping", isSleeping);
        }
        UpdatePlayerState();
    }


    float LOOK_KILL_DURATION = 3.0f;
    float lookTimer = 3.0f;
    void UpdatePlayerState()
    {
        if (isKeyPressed)
        {
            isSleeping = false;
            // hold all attacks?. no
        }
        else if (!isKeyPressed && cameraEventTrigger.isFullyFacingRoom)
        {
            isSleeping = true;
        }

        if (cameraEventTrigger.isFullyFacingRoom && gamemanager.isGameStart)
        {
            displayinfo.timerText.enabled = true;
            LookToKillEnemy();
        }
        else
        {
            displayinfo.timerText.enabled = false;
        }

    }

    private void LookToKillEnemy()
    {
        if (gamemanager.IsEnemyPeeking())
        {
            if (lookTimer > 0)
            {
                if (isSleeping)
                {
                    lookTimer = LOOK_KILL_DURATION;
                }
                lookTimer -= Time.deltaTime;
            }
            else if (lookTimer <= 0)
            {
                gamemanager.SetNoPeeker();
                lookTimer = LOOK_KILL_DURATION;
            }
        }
    }
}
