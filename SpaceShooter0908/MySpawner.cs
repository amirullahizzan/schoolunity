using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    float interval = 0.8f;
    public float timer = 0;

    float RandomizePos()
    {
        return Random.Range(-5, 5);
    }
    // Update is called once per frame

    void Update()
    {
        //InvokeRepeating("RandomizePos", 0f, 1f);
        timer += Time.deltaTime;
        if (timer > interval)
        {
            transform.position = new Vector3(RandomizePos(), transform.position.y, transform.position.z);
            Instantiate(asteroidPrefab, transform.position, transform.rotation);
        timer = 0;
        }
    }
}
