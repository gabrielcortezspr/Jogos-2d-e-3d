using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallplat : MonoBehaviour
{
    public float ftime;
    

    private TargetJoint2D tj;
    private BoxCollider2D bc;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        tj = GetComponent<TargetJoint2D>();
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    private void FixedUpdate()
    {
        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("fall", ftime);

        }
        if (collision.gameObject.layer == 8 )
        {
            bc.isTrigger = true;
        }


    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            Destroy(gameObject);
        }
    }
    void fall()
    {
        rb.velocity = Vector2.down * 10;
        tj.enabled = false;
        rb.mass = 10000;
        //bc.isTrigger = true;
    }
}
