using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public const float MAX_SLEEPY_LEVEL = 20.0f;
    float sleepyLevel = 0.0f; //if goes 100, Game Over
    const float MAX_TIME = 10.0f; 
    float timeElapsed = 0; //if goes 0, Win. 11 pm -> 05 am
    [HideInInspector] public int currentTime = 0; //if goes 0, Win. 11 pm -> 05 am
    private GameObject enemySpook;
    public GameObject[] enemiesSpookPrefabs;

    private GameObject enemyPeekingInstance;
    public GameObject[] enemiesPeekingPrefabs;
    public PlayerControl playercontrol;
    public CameraEventTrigger cameraEventTrigger;
    public bool isAttacking = false;
    float untilDeathTimer = 9999f;

    public bool isGameStart = false;
    public bool isIntroStart = false;

    private void Awake()
    {
    }
    private void Start()
    {
        RandomizeSpookTimer();
        RandomizePeekingTimer();
    }

    private void RandomizeSpookTimer()
    {
        const float MAX_DUR = 26.0f;
        const float MIN_DUR = 12.0f;
        spookTimer = UnityEngine.Random.Range(MIN_DUR, MAX_DUR);
    }

    float GetDiffMult()
    {
        return (MAX_TIME - timeElapsed * 0.002f);
    }
    private void RandomizePeekingTimer()
    {
        float MAX_DUR = 28.0f - GetDiffMult();
        float MIN_DUR = 15.0f - GetDiffMult();
        peekingTimer = UnityEngine.Random.Range(MIN_DUR, MAX_DUR);
    }

    public void ForceSpawnPeeking(peekingTypeEnum _peekingType)
    {
        peekingType = _peekingType;
        PeekSpawn();
    }

    void Update()
    {
        if (!isGameStart)
        {
            return;
        }
        isAttacking = true;
        if (isAttacking)
        {
            //dead anim
            SetPlayerDeath();
            return;
        }

        if (untilDeathTimer > 0 && peekingType == peekingTypeEnum.NOPEEKING)
        {
            EnemyTimers();
        }

        if (!isAttacking)
        {
            timeElapsed += Time.deltaTime;
            if(timeElapsed >= MAX_TIME)
            {
            timeElapsed = 0;
            currentTime += 1;
            }
            if (currentTime == 5) { print("YOU WIN"); }
        } //Display Clock

        if (!playercontrol.isSleeping)
        {
            const float SLEEPY_MULTIPLIER_INC = 1.6f;
            sleepyLevel += Time.deltaTime * SLEEPY_MULTIPLIER_INC;
        }
        else if(cameraEventTrigger.isFullyFacingWall)
        {
            if (sleepyLevel > 0)
            {
            const float SLEEPY_MULTIPLIER_DEC = 1.2f;
            sleepyLevel -= Time.deltaTime * SLEEPY_MULTIPLIER_DEC;
            
            Mathf.Clamp(sleepyLevel,0.0f, MAX_SLEEPY_LEVEL);
            }
        }

        if(sleepyLevel >= MAX_SLEEPY_LEVEL)
        {
            isAttacking = true;
        }

        if (peekingType != peekingTypeEnum.NOPEEKING)
        {
            if (untilDeathTimer <= 0)
            {
                isAttacking = true; //set jump and set dead
            }
        }


    }

    public void SetGameStart()
    {
        isGameStart = true;
        { playercontrol.cameraAnimator.SetBool("isGameStart", isGameStart); }
    }
    internal int GetSleepyLevel()
    {
        return (int)sleepyLevel;
    }

    public GameObject killmoveInstance;
    public GameObject killmovePrefab;
    public Transform killmoveT;
    public void SetPlayerDeath()
    {
        playercontrol.isSleeping = false;
        if(killmoveInstance) { return;} 
        playercontrol.cameraAnimator.SetBool("isEnemyAttacking",isAttacking);
        killmoveInstance = Instantiate(killmovePrefab,killmoveT.transform.position,killmoveT.rotation);
        //play audio after a few second,
        //then display death screen.
    }

    private void EnemyTimers()
    {

        if (spookTimer > 0 && spookType == spookTypeEnum.NOSPOOK) //can only tick one enemy spook
        {
            spookTimer -= Time.deltaTime;
        }
        else if (spookTimer <= 0 && spookType == spookTypeEnum.NOSPOOK)
        {
            SpookRandomSpawn();
            RandomizeSpookTimer();
            // set no spook on the end of animation
        }

        if (peekingTimer > 0 && peekingType == peekingTypeEnum.NOPEEKING) //can only tick one enemy peeking
        {
            peekingTimer -= Time.deltaTime;
        }
        else if (peekingTimer <= 0 && peekingType != peekingTypeEnum.NOPEEKING)
        {
            PeekRandomize();
            PeekSpawn();
            RandomizePeekingTimer();
        }
    }

    //SPOOK
    public void SetNoSpook()
    {
        Destroy(enemySpook.gameObject);
        spookType = spookTypeEnum.NOSPOOK;
    }

    int MAX_SPOOK_TYPE = Enum.GetNames(typeof(spookTypeEnum)).Length;

    spookTypeEnum spookType = spookTypeEnum.NOSPOOK;
    enum spookTypeEnum
    {
        NOSPOOK = 0,
        DOORSPOOK,
        WINDOWSPOOK,
        CORRIDORSPOOK
    };

    float spookTimer = -999.0f;

    private void SpookRandomSpawn()
    {
        spookType = (spookTypeEnum)UnityEngine.Random.Range(1, MAX_SPOOK_TYPE);
        enemySpook = enemiesSpookPrefabs[(int)spookType];
        Instantiate(enemySpook.gameObject);
        print("Spawning spooks" + spookType);
    }

    //PEEK

    int MAX_PEEKING_TYPE = Enum.GetNames(typeof(peekingTypeEnum)).Length;
    peekingTypeEnum peekingType = peekingTypeEnum.NOPEEKING;
    public enum peekingTypeEnum
    {
        NOPEEKING = 0,
        DOORPEEKING,
        WINDOWPEEKING,
        WARDROBEPEEKING,
        BEDPEEKING,
    };
    float peekingTimer = 0.0f;

    public Transform doorPeekingT;
    public Transform windowPeekingT;
    public Transform wardrobePeekingT;
    private void PeekRandomize()
    {
        peekingType = (peekingTypeEnum)UnityEngine.Random.Range(1, MAX_PEEKING_TYPE);
    }
    private void PeekSpawn()
    {
        GameObject prefab = enemiesPeekingPrefabs[(int)peekingType];

        switch (peekingType)
        {
            case peekingTypeEnum.NOPEEKING:
                break;
            case peekingTypeEnum.DOORPEEKING:
                enemyPeekingInstance = Instantiate(prefab.gameObject, doorPeekingT.position, doorPeekingT.rotation);
                break;
            case peekingTypeEnum.WINDOWPEEKING:
                enemyPeekingInstance = Instantiate(prefab.gameObject, windowPeekingT.position, windowPeekingT.rotation);
                break;
            case peekingTypeEnum.WARDROBEPEEKING:
                enemyPeekingInstance = Instantiate(prefab.gameObject, wardrobePeekingT.position, windowPeekingT.rotation);
                break;
            case peekingTypeEnum.BEDPEEKING:
                break;
            default:
                break;
        }

        print("Spawning peekers : " + peekingType);
    }

    public void SetNoPeeker()
    {
        untilDeathTimer = 9999.0f;
        Destroy(enemyPeekingInstance.gameObject);
        print("Destroying peekers : " + enemyPeekingInstance.gameObject);
        peekingType = peekingTypeEnum.NOPEEKING;
    }

    internal peekingTypeEnum GetPeekerIndex()
    {
        return peekingType;
    }

    public bool IsEnemyPeeking()
    {
        return GetPeekerIndex() != peekingTypeEnum.NOPEEKING;
    }
}
