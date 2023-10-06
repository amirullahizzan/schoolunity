using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5f;

    Rigidbody rb;
    Vector3 direction;
    bool isCharacter;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        isCharacter = rb.constraints.HasFlag(RigidbodyConstraints.FreezeRotationX)
            && !rb.constraints.HasFlag(RigidbodyConstraints.FreezeRotationY)
            && rb.constraints.HasFlag(RigidbodyConstraints.FreezeRotationZ);
    }

    void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (isCharacter && direction.sqrMagnitude > 0)
        {
            transform.LookAt(transform.position + Vector3.RotateTowards(transform.forward, direction.normalized, Time.deltaTime * Mathf.PI * 2f, 0));
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(direction * speed);

        if (isCharacter)
        {
            rb.angularVelocity = Vector3.zero;
        }
    }
}
