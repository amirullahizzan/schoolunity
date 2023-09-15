using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemy : MonoBehaviour
{
    float forwardspeed = 3.0f;
    public GameObject effectPrefab;
    public GameObject scoreObject;
    public MyScore score;
    // Start is called before the first frame update
    private void Start()
    {
        //scoreObject = GameObject.FindGameObjectWithTag("Score");
        score = GameObject.Find("Score").GetComponent<MyScore>();
        Destroy(gameObject,10f);
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -20 || transform.position.z > 20)
        {
            Destroy(gameObject);
        }
        transform.position += transform.forward * Time.deltaTime * forwardspeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        //scoreObject.AddScore();
        //scoreObject.SendMessage("AddScore");
        Destroy(Instantiate(effectPrefab,transform.position,transform.rotation),2f);
        score.AddScore();
        Destroy(gameObject);
    }
}
