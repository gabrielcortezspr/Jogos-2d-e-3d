using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class caveraReborn : MonoBehaviour
{
    SpriteRenderer sr;
    public CircleCollider2D col1;
    public PolygonCollider2D col2;
    public Animator a;
    public Transform target;
    public float speed = 5f;
    public float rotateSpeed = 200f;
    float lunget = 0f;
    float lungec = 3f;
    float cdt = 0;
    float cd = 5;
    

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        //col1.enabled = false;
        //col2.enabled = false;
        
    }
    private void Awake()
    {
        Debug.Log("o gigante acordo");
        cdt = cd;
    }

    private void Update()
    {
        cdl();
        //corrigir();
        
       
        

        if (cdt > 0)
        {
            cdt -= Time.deltaTime;
        }
        if (cdt < 0)
        {
            cdt = 0;
        }
        if(cdt == 0)
        {

        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();
        float rotateAmount = Vector3.Cross(direction, transform.right).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.velocity = transform.right * speed;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Nagazaki"))
        {
            Debug.Log("morrestes :(");
            soundmanagero.PlaySound("sHit");
            nag.ceifado = true;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //nag.dead = false;

        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        
        
        if (collision.gameObject.name.Equals("Nagazaki")&& lunget == 0)
        {
            soundmanagero.PlaySound("rar");
            a.SetTrigger("dash");
            lunget = lungec;
            
        }
    }

    void cdl()
    {
        

        if (lunget > 0)
        {
            lunget -= Time.deltaTime;
        }
        if (lunget < 0)
        {
            lunget = 0;
        }
        
    }
    //void corrigir()
    //{
    //    //if(rb.transform.eulerAngles.z > 90)
    //    //{
    //    //    sr.flipY = true;
    //    //}


    //    if (rb.transform.eulerAngles.z > 0)
    //    {
    //        sr.flipY = false;
    //    }

    //    if (rb.transform.eulerAngles.z < 0)
    //    {
    //        sr.flipY = true;
    //    }

    //    //if (rb.transform.eulerAngles.z < -90)
    //    //{
    //    //    sr.flipY = true;
    //    //}
    //}
    
}
