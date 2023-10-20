using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Transform nextPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemyScript = other.GetComponent<Enemy>();
        if(enemyScript)
        {
            enemyScript.chasepointT = nextPoint;
        }
    }
}
