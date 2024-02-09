using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;

public class CameraEventTrigger : MonoBehaviour
{
    public DisplayInfo displayinfo;
    public GameObject titleGO;
    public GameManager gamemanager;
    public GameObject deathScreenGO;

    public bool isFullyFacingWall = false;
    public bool isFullyFacingRoom = false;
    public void SetFullyFacingRoom()
    {
        isFullyFacingWall = false;
        isFullyFacingRoom = true;
    }

    public void SetNotFullyFacingRoom()
    { 
        isFullyFacingRoom = false;
    }


    public void SetFullyFacingWall()
    {
       isFullyFacingRoom = false;
       isFullyFacingWall = true;
    }

    public GameObject lampObject;
    public void TurnOffLamp()
    {
        Destroy(lampObject);
        titleGO.SetActive(true);
    }


    public void SpawnFirstPeeker()
    {
        gamemanager.ForceSpawnPeeking(GameManager.peekingTypeEnum.DOORPEEKING);
    }
    public void StartGameTrigger()
    {
        gamemanager.SetGameStart();
    }
    // Start is called before the first frame update
    public void DeathTrigger()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void GameOverScreenTrigger()
    {
        deathScreenGO.SetActive(true);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
