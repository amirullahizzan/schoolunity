using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTopTrigger : MonoBehaviour
{
    public GameObject normalblockObject;
    public GameObject destroyedblockObject;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DelayDestroyBlock ()
    {
        normalblockObject.SetActive(false);
        destroyedblockObject.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool isStepped = false;
        if(collision.CompareTag("Player"))
        {
            animator = normalblockObject.GetComponent<Animator>();
            isStepped = true;
            animator.SetBool("shake", isStepped);
            Invoke("DelayDestroyBlock",2f);
        }
    }
}
