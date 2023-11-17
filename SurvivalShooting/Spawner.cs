using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject zombunnyPrefab;

    float timer = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnerTick();
    }

    private void SpawnerTick()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
        float randomVector_x = Random.Range(0f,10f);
        float randomVector_z = Random.Range(0f,10f);
            Instantiate(zombunnyPrefab,new Vector3(randomVector_x,0, randomVector_z),transform.rotation);
            timer = 0;
        }
    }
}
