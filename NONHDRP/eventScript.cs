using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventScript : MonoBehaviour
{
    GameManager gameManager;
    public Animator doorAnimator;
    public Light outsideLight;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameManager.GetPeekerIndex())
        {
            case GameManager.peekingTypeEnum.NOPEEKING:
               doorAnimator.SetBool("isEnemySpawn", false);
                outsideLight.enabled = enabled;

                break;
            case GameManager.peekingTypeEnum.DOORPEEKING:
                doorAnimator.SetBool("isEnemySpawn", true);
                outsideLight.enabled = false;
                break;
            case GameManager.peekingTypeEnum.WINDOWPEEKING:
                break;
        }
    }
}
