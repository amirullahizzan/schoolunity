using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject normalblockObject;
    public GameObject destroyedblockObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            normalblockObject.SetActive(false);
            destroyedblockObject.SetActive(true);
            Destroy(gameObject, 1);
        }
    }
}
