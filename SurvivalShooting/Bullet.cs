using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    LineRenderer line;
    void Start()
    {
            //destroy component
        
        //Destroy(GameObject,0.2f);
        line = GetComponent<LineRenderer>();
        Ray ray = new Ray(transform.position,transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,15f))
        { 
            //the objects that get hit
           //hit.distance

            line.SetPosition(1,new Vector3 (0,0,hit.distance));
        }
        Destroy(line, 0.05f);
        Destroy(gameObject, 0.8f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
