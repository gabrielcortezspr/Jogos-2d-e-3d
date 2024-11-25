using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chin : MonoBehaviour
{
    
    bool freio = false;
    [Header("Atacamentos")]
    public static bool morto;
    public float desaceleracaoNatural;
    public float velocidade;
    public float pulao;
    public float mph;
    Rigidbody2D rb;
    public ParticleSystem ps;
    Animator a;
    [Header("GPS")]
    public Vector2 velocidadeXY;
    [Header("Collision")]
    public bool onGround = false;
    public bool emparedado = false;
    public float sensorR;
    //public float paredeLenght;
    public float groundLength = 1.1f;
    public Vector3 colliderOffset = new Vector3(0.24f, 0f, 0f);
    public LayerMask groundLayer;
    public LayerMask rampaLayer;
    public Transform sensorRT, sensorLT, senslb, sensrb;

    [Header("Mecanicas")]
    public float maxSpeed;
    float nitro;
    public float fallMult;
    public float lowJumpMult;
    public float bateriagauge;
    public static float bateria;

    [Space]
    public static bool rampavel;
    public static bool pilhado;
    public static float pilhadocd;
    public float desaceleracaoEmparedado;
    float forgivetime = 0.05f;
    bool forgiveblock = false;
    float forgiveblocktimer;

    
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        a = GetComponent<Animator>();
        GetComponent<EdgeCollider2D>().enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        a.SetBool("rip", false);
        bateria = 10;
    }

    
    void Update()
    {
        if (morto)
        {
            a.SetBool("rip", true);
            GetComponent<EdgeCollider2D>().enabled = false;
            rb.bodyType = RigidbodyType2D.Kinematic;
            return;
        }
        bateriagauge = bateria;
        if (onGround)
        {
            forgivetime = 0.05f;
        }
        else if(forgivetime > 0)
            forgivetime -= Time.deltaTime;

        
       
        
        
        Geps();
        if(bateria > 0 && !pilhado)
        {
            bateria -= Time.deltaTime;
        }
        if(bateria < 0)
        {
            Gerente.Resetamento(0);
        }
        if (pilhado)
        {
            pilhadocd -= Time.deltaTime;
            if (pilhadocd < 0)
            {
                pilhado = false;
            }
        }
        
        if (Input.GetAxis("Horizontal") > 0 && rb.velocity.x < 0)
        {
            freio = true;
            
        }
        else if (Input.GetAxis("Horizontal") < 0 && rb.velocity.x > 0)
        {
            freio = true;
            
        }
        else freio = false;
        onGround = Physics2D.Raycast(sensrb.position, Vector2.left, groundLength, groundLayer) || Physics2D.Raycast(senslb.position, Vector2.right, groundLength, groundLayer) || Physics2D.Raycast(sensrb.position, Vector2.left, groundLength, rampaLayer) || Physics2D.Raycast(senslb.position, Vector2.right, groundLength, rampaLayer);
        emparedado = Physics2D.Raycast(sensorLT.position, Vector2.down, sensorR,groundLayer)|| Physics2D.Raycast(sensorRT.position, Vector2.down, sensorR,groundLayer);
        //emparedado = Physics2D.Raycast(transform.position + offset, transform.TransformDirection(Vector2.up), paredeLenght, groundLayer)|| Physics2D.Raycast(transform.position - offset, transform.TransformDirection(Vector2.up), paredeLenght, groundLayer)||
        //Physics2D.Raycast(transform.position + offset, transform.TransformDirection(Vector2.down), -paredeLenght, groundLayer) || Physics2D.Raycast(transform.position - offset, transform.TransformDirection(Vector2.down), -paredeLenght, groundLayer);
        

        if (emparedado)
        {
            
            mph *= -1;
        }
        
        //{
        //    mph *= -1 / 2;

        //    if (mph > 0)
        //    {
        //        mph -= Time.deltaTime * desaceleracaoNatural;
        //    }
        //    if (mph < 0)
        //    {
        //        mph += Time.deltaTime * desaceleracaoNatural;
        //    }
        //}
        //emparedado = Physics2D.Raycast(transform.position + offset2, Vector2.right, paredeLenght, groundLayer) || Physics2D.Raycast(transform.position -offset2, Vector2.right, paredeLenght, groundLayer);
        if(rb.velocity.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }else if(rb.velocity.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        Pulo();
    }
    
    

    private void FixedUpdate()
    {
        mph += Input.GetAxis("Horizontal") * velocidade; 
        rb.velocity = new Vector2(mph, rb.velocity.y);
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    nitro = 10;
        //}
        /*else */if (nitro > 0)
            nitro -= Time.deltaTime * 3.5f;

        if (mph > maxSpeed + nitro)
        {
            mph = (maxSpeed + nitro) - 0.1f;
        }
        if (mph < -maxSpeed + -nitro)
        {
            mph = (-maxSpeed + -nitro) + 0.1f;
        }
        if (mph > 0 && Input.GetAxis("Horizontal") == 0)
        {
            mph -= Time.deltaTime * desaceleracaoNatural;
        }
        if (mph < 0 && Input.GetAxis("Horizontal") == 0)
        {
            mph += Time.deltaTime * desaceleracaoNatural;
        }
        if (freio)
        {
            velocidade = 0.3f;
            a.SetBool("brek", true);
            ps.Play();

        }
        else 
        { 
            velocidade = 0.1f;
            a.SetBool("brek", false);
            ps.Clear();
            ps.Pause();
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 10)
        {
            if (mph > 3)
            {
                mph -= 3;
            }
            else if (mph < 3)
            {
                mph += 3;
            }
            else mph = 0;
        }
        if (collision.gameObject.layer == 12)
        {
            Gerente.Resetamento(0);
            Soundmanagero.PlaySound("morte");
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "spd")
        {
            nitro = 10;
            if(mph > 0)
            {
                mph += Time.deltaTime * 9;
            }else if(mph < 0)
            {
                mph -= Time.deltaTime * 9;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D jurupinga)
    {
        if(jurupinga.gameObject.tag == "batera")
        {
            Soundmanagero.PlaySound("bateria");
        }
    }
    void Pulo()
    {
        if (Input.GetButtonDown("Jump") && onGround || Input.GetButtonDown("Jump") && forgivetime > 0 && !forgiveblock || Input.GetButtonDown("Jump") && rampavel)
        {
            forgivetime = 0;
            forgiveblock = true;
            forgiveblocktimer = 0.3f;
            rb.velocity = new Vector2(rb.velocity.x, 0);
         rb.AddForce(new Vector2(0f, pulao), ForceMode2D.Impulse);
            
           
        }
        if (forgiveblocktimer > 0)
        {
            forgiveblocktimer -= Time.deltaTime;
        }
        else forgiveblock = false;
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(senslb.position, senslb.position + Vector3.right * groundLength);
        Gizmos.DrawLine(sensrb.position, sensrb.position + Vector3.left * groundLength);
        
        
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(sensorLT.position, sensorLT.position + Vector3.down * sensorR);
        Gizmos.DrawLine(sensorRT.position, sensorRT.position + Vector3.down * sensorR);
        //Gizmos.DrawLine(transform.position + offset2, transform.position + offset2 + Vector3.right * paredeLenght);
        //Gizmos.DrawLine(transform.position - offset2, transform.position - offset2 + Vector3.right * paredeLenght);
    }
    void Geps()
    {
        velocidadeXY = rb.velocity;
    }
}
