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
           Debug.DrawRay(ray.origin,ray.direction*15f,Color.red,5f);
        if (Physics.Raycast(ray,out hit,15f))
        { 
            //the objects that get hit
           //hit.distance
            line.SetPosition(1,new Vector3 (0,0,hit.distance));

            Enemy enemyScript = hit.collider.GetComponent<Enemy>();
            //if(enemyScript != null)
            if (enemyScript)
            {
                print("Hit!");
                enemyScript.TakeDamage();
            }
        }
        Destroy(line, 0.05f);
        Destroy(gameObject, 0.8f);
    }

    // Update is called once per frame
  
}
