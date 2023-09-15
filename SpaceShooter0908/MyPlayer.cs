using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    public float speed = 5f;    
   Animator animator;
   public GameObject bulletPrefab;
   public GameObject effectPrefab;
   public float shootinterval = 3f;
   [SerializeField] float shootcooldown = 0f;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        //animator.applyRootMotion = true;
    }
    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontal, 0, Input.GetAxis("Vertical"));
        //animator.SetFloat("Roll",horizontal);   
        animator.SetFloat("Roll",direction.x);   
        transform.position += speed * direction * Time.deltaTime;

        Debug.Log(transform.position.x);
        if(transform.position.x <= -6)
        {
            transform.position = new Vector3(-6, 0, transform.position.z);
        }
        else if(transform.position.x >= 6)
        {
            transform.position = new Vector3(6, 0, transform.position.z);

        }

    }

    void Shoot()
    {
        if(Input.GetKey(KeyCode.Mouse0) && shootcooldown <= 0) //Input.GetButtonDown("Fire")
        {
        shootcooldown = shootinterval;
        Instantiate(bulletPrefab, transform.position,transform.rotation);
        Destroy(Instantiate(effectPrefab, transform.position,transform.rotation),1.0f);
        }
        if(shootcooldown > 0)
        {
            shootcooldown -= Time.deltaTime;
        }
    }
    // Update is called once per frame
    void Update()
    {
     Movement();
     Shoot();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

}
