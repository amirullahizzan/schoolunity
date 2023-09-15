using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBullet : MonoBehaviour
{
    float bulletspeed = 10f;


    private void Start()
    {
        Destroy(gameObject,5f);
    }
    // Update is called once per frame
    void Update()
    {
        //transform.position += new Vector3(0, 0, 1f) * Time.deltaTime * bulletspeed;
        //transform.localPosition += new Vector3(0, 0, 1f) * Time.deltaTime * bulletspeed;
        transform.position += transform.forward * Time.deltaTime * bulletspeed;

        if(transform.position.z > 100)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
    Destroy(gameObject);     
    }
}
