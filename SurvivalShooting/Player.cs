using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    SpriteRenderer spriterenderer;
    Animator animator;
    bool isGround = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    void BlinkSprite()
    {
        if (damageframe % 3 == 0)
        {
            spriterenderer.enabled = !spriterenderer.enabled;
        }
    }
    void Update()
    {
        stunTimer -= Time.deltaTime;
        if (stunTimer <= 0)
        {
            Control();
            damageframe++;
            stunTimer = 0;
            animator.SetBool("damage", false);
            damageframe = 0;
            spriterenderer.enabled = true;
        }
        else
        {
            BlinkSprite();
        }
    }
    float groundCount = 0;
    float moveSpeed = 5f;
    float base_moveSpeed = 5f;
    void Control()
    {
        //Vector2 vectorspeed = new Vector2(4f,0);
        //rb.velocity = new Vector2(Input.GetAxis("Horizontal")*moveSpeed,rb.velocity.y);
        ////if(   Input.GetButtonDown("Jump") );
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    rb.velocity += new Vector2(rb.velocity.x, jumpPower);
        //}
        Vector2 v = rb.velocity;
        float jumpPower = 18f;
        
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            Debug.Log("sprint keypressed");
            moveSpeed = 10f;
        }
        else
        {
           moveSpeed = base_moveSpeed;
        }

        if (groundCount > 0)
        {
            isGround = true;
        }
        else
        {
            isGround = false;
        }

        v.x = Input.GetAxis("Horizontal") * moveSpeed;
        if(Input.GetAxis("Horizontal") > 0.5f)
        {
        }


        animator.SetFloat("move", Mathf.Abs(rb.velocity.magnitude));
        animator.SetBool("isground", isGround );

   
        if(Input.GetButtonDown("Jump") && isGround)
        {
           
            v.y = jumpPower;
            isGround = false;
        }
       


        if(rb.velocity.x < 0)
        {
            spriterenderer.flipX = true;
            //gameObject.transform.rotation = new Vector3(transform.rotation.x,180, transform.rotation.z);
        }
        else if(rb.velocity.x > 0)
        {
            spriterenderer.flipX = false;
            //gameObject.transform.Rotate(transform.rotation.x, 0, transform.rotation.z);
        }

        rb.velocity = v;

     
    }
    int hp = 3;

    float stunTimer;
    public void Damage()
    {
        hp -= 1;
        stunTimer = 1.0f;

        Debug.Log("damage is triggered");

        if(spriterenderer.flipX)
        {
            rb.velocity = new Vector2(-5f, 5f);
        }
        else
        {
            rb.velocity = new Vector2(-5f,5f);
        }

        animator.SetBool("damage", true);

       
    }
        int damageframe = 0;

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //isGround = true;
    //    groundCount++;
    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    //isGround = false;
    //    groundCount--;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //isGround = true;
        groundCount++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //isGround = false;
        groundCount--;
    }
}
