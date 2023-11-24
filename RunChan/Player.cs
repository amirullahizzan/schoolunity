using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    Sprite sprite;
    Animator animator;
    bool isGround = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Control();
    }

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
        float moveSpeed = 5f;
        float jumpPower = 5f;

        v.x = Input.GetAxis("Horizontal") * moveSpeed;
        animator.SetFloat("move", Mathf.Abs(rb.velocity.magnitude));
        animator.SetBool("isground", isGround );

        if(Input.GetButtonDown("Jump") && isGround)
        {
            v.y = jumpPower;
            isGround = false;
        }
        if(rb.velocity.x < 0)
        {
            //gameObject.transform.rotation = new Vector3(transform.rotation.x,180, transform.rotation.z);
        }
        else
        {
            //gameObject.transform.Rotate(transform.rotation.x, 0, transform.rotation.z);
        }

        rb.velocity = v;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
    }
}
