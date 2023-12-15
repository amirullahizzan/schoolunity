using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame updatep
    public BoxCollider2D parentCollider;
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit, 15f))

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Player playerscript;
            playerscript = collision.GetComponent<Player>();
            playerscript.Damage();
        }
    }

}
