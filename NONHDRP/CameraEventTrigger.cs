using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;

public class CameraEventTrigger : MonoBehaviour
{
    public DisplayInfo displayinfo;

    public bool isFullyFacingWall = false;
    public bool isFullyFacingRoom = false;
    public void SetFullyFacingRoom()
    {
        isFullyFacingWall = false;
        isFullyFacingRoom = true;
    }

    public void SetFullyFacingWall()
    {
        displayinfo.timerText.enabled = true;
       isFullyFacingRoom = false;
       isFullyFacingWall = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
