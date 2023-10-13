using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Start()
    {
    rb = GetComponent<Rigidbody>();    
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
        Aim();
        animator.SetFloat("Speed", rb.velocity.magnitude);
    }

    private void Aim()
    {
        //print(Input.mousePosition);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

            if(Physics.Raycast(ray,out hit,100f, mask))
        {
            //hit.point;
            transform.LookAt(new Vector3(hit.point.x,0, hit.point.z));
        }
    }

    void Move()
    {
            
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal") ,0, Input.GetAxis("Vertical"));
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
        if(Input.GetButtonDown("Fire1"))
        {
            //Destroy(Instantiate(bulletPrefab, gunPosition.position, transform.rotation),0.2f);
            Instantiate(bulletPrefab, gunPosition.position, transform.rotation);
            
        }
    }
}
