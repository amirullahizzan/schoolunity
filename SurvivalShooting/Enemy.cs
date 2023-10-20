using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent navmesh;
    public Transform chasepointT;
    public Transform playerT;
    
    public int life = 3;
    AudioSource se;


    // Start is called before the first frame update
    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
        se = GetComponent<AudioSource>();
        //playerT = GameObject.Find("Player").GetComponent<Transform>();
        //playerT = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if(!playerT)
        {
        playerT = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if (!chasepointT)
        {
            chasepointT = playerT;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (chasepointT)
        {
            navmesh.SetDestination(chasepointT.position);
        }
        //if(navmesh);
        if (chasepointT && Vector3.Distance(gameObject.transform.position, playerT.transform.position) <= 5)
        {
            chasepointT = playerT;
        }

        

        //if (Input.GetButtonDown("Fire1"))
        //{
        //TakeDamage();
        //}
    }

    public void TakeDamage()
    {
        life--;
        se.Play();
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Player playerScript = other.GetComponent<Player>();
        if (other.CompareTag("Player") && playerScript)
        {
            //Player playerScript = other.GetComponent<Player>();
            playerScript.TakeDamage();
        }
    }
}
