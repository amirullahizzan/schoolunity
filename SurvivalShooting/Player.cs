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
    public Transform gunPositionleft;
    public Transform gunPositionright;
    public LayerMask mask;
    public GameObject gameoverObject;
    Animator animator;
    //public Vector3 gunVector3;
    float base_speed = 3f;
    float speed = 3f;
    bool isAlive = true;
    // Start is called before the first frame update

    AudioSource se;

    public GameObject[] heartObjects;

    const int MAX_HEART = 3;
    public int life = MAX_HEART;
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
        if (!isAlive)
        {
            return;
        }

        if (hitcooldown <= 0)
        {
            se.Play();
            hitcooldown = 3;
            life--;
            for (int i = 0; i < heartObjects.Length; i++)
            {
                //if (i < life)
                //{
                //    heartObjects[i].SetActive(true);
                //}
                //else
                //{
                //    heartObjects[i].SetActive(false);
                //}
                heartObjects[i].SetActive(i<life);
            }
        }
        if (life <= 0) 
            { 
            isAlive = false;
            animator.SetBool("IsAlive", !isAlive);
            GetComponent<Collider>().enabled = false ;
             rb.velocity = new Vector3(0,0,0);
            gameoverObject.SetActive(true);
            }


    }
    float shoottimer = 0f;

    // Update is called once per frame
    void Update()
    {

        if(!isAlive)
        {
            return;
        }   
        Move();
        Fire();
        Aim();
        animator.SetFloat("Speed", rb.velocity.magnitude);
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

    float dodge_dur = 3f;
    const float base_dodge_cooldown = 5;
    float dodge_cooldown = base_dodge_cooldown;
    void Move()
    {
    const float DODGEMULT = 8;

        Vector3 direction = new Vector3 (Input.GetAxis("Horizontal"),0 , Input.GetAxis("Vertical"));
        //var position = transform.localPosition;
        //position.x += (Input.GetAxis("Horizontal"));
        //position.z += (Input.GetAxis("Vertical"));

        rb.velocity = direction * speed;
        dodge_dur-=Time.deltaTime;
        dodge_cooldown-=Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) && dodge_cooldown <= 0)
        {
            speed = DODGEMULT;
            Debug.Log("pressed");
            dodge_dur = 0.3f;
        }
        if(dodge_dur < 0)
        {
            speed = base_speed;
        }



    }

    float shoottimershotgun = 0.0f;

    const float base_ulti_cooldown = 5.0f;
    float ulti_cooldown = base_ulti_cooldown;

    void Fire()
    {
        shoottimer += Time.deltaTime;

        //Input.GetButtonDown("Fire1");
        if (Input.GetButton("Fire1") && shoottimer >= 0.4f)
        {
            //Destroy(Instantiate(bulletPrefab, gunPosition.position, transform.rotation),0.2f);
            Destroy(Instantiate(bulletPrefab, gunPosition.position, transform.rotation),0.2f);
            shoottimer = 0;

        }
        shoottimershotgun+=Time.deltaTime;
        if (Input.GetButton("Fire2") && shoottimershotgun >= 0.6f)
        {
            //(Instantiate(bulletPrefab, gunPosition.position, transform.rotation),0.2f);
            Destroy(Instantiate(bulletPrefab, gunPosition.position, transform.rotation),0.2f);
            Destroy(Instantiate(bulletPrefab, gunPositionleft.position, gunPositionleft.rotation),0.2f);
            Destroy(Instantiate(bulletPrefab, gunPositionright.position, gunPositionright.rotation), 0.2f);
            shoottimershotgun = -1;
        }

        ulti_cooldown+=Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && ulti_cooldown >= base_ulti_cooldown)
        {
            for(int i = 0; i < 36; i++)
            {
                Quaternion newrotation = Quaternion.Euler(0,10*i,0);

                Quaternion rotatedQuaternion = newrotation * transform.rotation;

                Destroy(Instantiate(bulletPrefab, gunPosition.position, rotatedQuaternion),1.0f);
            }
            ulti_cooldown = 0;
        }
    }

    public float GetUltiCooldown()
    {
        return ulti_cooldown;
    }

}
