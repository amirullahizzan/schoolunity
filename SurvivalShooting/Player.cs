using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{

    Rigidbody rb;
    public GameObject bulletPrefab;
    public Transform gunPosition;
    public LayerMask mask;
    Animator animator;
    //public Vector3 gunVector3;
    float speed = 3f;
    // Start is called before the first frame update

    AudioSource se;

    public int life = 5;
    float hitcooldown = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();    
        animator = GetComponent<Animator>();
        se = GetComponent<AudioSource>();
        //cameraTransform = GameObject.Find("").GetComponent<Camera>()
    }

    public void TakeDamage()
    {
        if (hitcooldown <= 0)
        {
            se.Play();
            hitcooldown = 3;
            life--;
        }
            if (life <= 0)
            {
                //destroy
                Destroy(gameObject);
            }
        
    }
    float shoottimer = 0f;

    // Update is called once per frame
    void Update()
    {

        Move();
        Fire();
        Aim();
        animator.SetFloat("Speed", rb.velocity.magnitude);
        shoottimer+=Time.deltaTime;
        hitcooldown -= Time.deltaTime;
    }


    private void Aim()
    {
        //print(Input.mousePosition);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

            if(Physics.Raycast(ray,out hit,100f, mask))
        {
            //hit.point;

            //print(hit.transform.name);
            transform.LookAt(new Vector3(hit.point.x,0, hit.point.z));

        }
    }

    void Move()
    {
            
        Vector3 direction = new Vector3 (Input.GetAxis("Horizontal"),0 , Input.GetAxis("Vertical"));
        //var position = transform.localPosition;
        //position.x += (Input.GetAxis("Horizontal"));
        //position.z += (Input.GetAxis("Vertical"));

        rb.velocity = direction * speed;

        if(Input.GetKey(KeyCode.Q))
        {
            //rb.AddTorque(0,-3f,0);

           transform.Rotate(0,-3,0);
        }
        else if(Input.GetKey(KeyCode.E))
        {
            //rb.AddTorque(0, 3f, 0);
            transform.Rotate(0, 3, 0);
        }

        

    }


    void Fire()
    {
        //Input.GetButtonDown("Fire1");
        if(Input.GetButton("Fire1") && shoottimer >= 0.2f)
        {
            //Destroy(Instantiate(bulletPrefab, gunPosition.position, transform.rotation),0.2f);
            Instantiate(bulletPrefab, gunPosition.position, transform.rotation);
            shoottimer = 0;

        }
    }
}
