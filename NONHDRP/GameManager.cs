using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float sleepyLevel = 0.0f; //if goes 100, Game Over
    const float MAX_TIME = 6000.0f; //if goes 0, Win. 11 pm -> 05 am
    float timeLeft = MAX_TIME; //if goes 0, Win. 11 pm -> 05 am
    public int currentTime = 11; //if goes 0, Win. 11 pm -> 05 am
    public GameObject enemyPeeking;
    public PlayerControl playercontrol;
    public CameraEventTrigger cameraEventTrigger;
    public bool isAttacking = false;
    float untilDeathTimer = 9999f;


    private void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking)
        {
            timeLeft -= Time.deltaTime;
            if(currentTime == 12) { currentTime = 0; }
            currentTime += (int)MAX_TIME % 1000;
        } //Display Clock
        const float SLEEPY_MULTIPLIER = 0.8f;
        if(!playercontrol.isSleeping)
        {
        sleepyLevel += Time.deltaTime * SLEEPY_MULTIPLIER;
        }

        if(peekingType != peekingTypeEnum.NOPEEKING)
        {
            if(untilDeathTimer <= 0)
            {
            isAttacking = true; //set jump and set dead
            }
        }

        if(untilDeathTimer > 0)
        {
            EnemyTimers();
        }
    }

    internal int GetSleepyLevel()
    {
        return (int)sleepyLevel;
    }

    public void DeleteAllEnemy()
    {
        if (!isAttacking) 
        { 
            untilDeathTimer = 9999.0f; 
            Destroy(enemyPeeking);
            isPeeking = false;
            peekingType = peekingTypeEnum.NOPEEKING;
        }
     
    }

    public void SetPlayerDeath()
    {
        //play audio after a few second,
        //then display death screen.
    }

    private void EnemyTimers()
    {
            const float MAX_DUR = 35.0f;
            const float MIN_DUR = 15.0f;
        
        if(spookTimer > 0 && spookType == spookTypeEnum.NOSPOOK) //can only tick one enemy spook
        {
        spookTimer -= Time.deltaTime;
        }
        else
        {
            SpookRandomizer();
            spookTimer = UnityEngine.Random.Range(MIN_DUR, MAX_DUR);
            // set no spook on the end of animation
        }

        if (peekingTimer > 0 && peekingType == peekingTypeEnum.NOPEEKING) //can only tick one enemy peeking
        {
            peekingTimer -= Time.deltaTime;
        }
        else
        {
            if(!isPeeking){PeekRandomizer(); }
            isPeeking = true;
            peekingTimer = UnityEngine.Random.Range(MIN_DUR, MAX_DUR);
        }
    }

    //SPOOK

    int MAX_SPOOK_TYPE = 3;
    spookTypeEnum spookType = spookTypeEnum.NOSPOOK;
    enum spookTypeEnum
    {
        NOSPOOK = 0,
        DOORSPOOK,
        WINDOWSPOOK,
        CORRIDORSPOOK
    };

    float spookTimer = 0.0f;

    private void SpookRandomizer()
    {
        spookType = (spookTypeEnum)UnityEngine.Random.Range(1, MAX_SPOOK_TYPE);
    }

    //PEEK

    int MAX_PEEKING_TYPE = 3;
    peekingTypeEnum peekingType = peekingTypeEnum.NOPEEKING;
    enum peekingTypeEnum
    {
        NOPEEKING = 0,
        DOORPEEKING,
        WINDOWPEEKING,
        CEILINGPEEKING,
    };
    float peekingTimer = 0.0f;
    bool isPeeking = false; //only one peeker
    private void PeekRandomizer()
    {
        peekingType = (peekingTypeEnum)UnityEngine.Random.Range(1, MAX_PEEKING_TYPE);
    }
}
