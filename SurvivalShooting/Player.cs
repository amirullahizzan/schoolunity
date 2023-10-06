using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody rb;
    public GameObject bulletPrefab;
    public Transform gunPosition;
    //public Vector3 gunVector3;
    float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
    rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
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
        if(Input.GetButtonDown("Fire1"))
        {
            //Destroy(Instantiate(bulletPrefab, gunPosition.position, transform.rotation),0.2f);
            Instantiate(bulletPrefab, gunPosition.position, transform.rotation);
            
        }
    }
}
