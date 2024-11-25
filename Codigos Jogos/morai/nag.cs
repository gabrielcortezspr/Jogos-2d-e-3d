using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;


public class nag : MonoBehaviour
{
    [Header("informaçoes")]
    public float veloX;
    public float veloY;
    public static bool ceifado = false;

    [Space]

    [Header("Collision")]
    public bool onGround = false;
    private float groundLength = 1.1f;
    private Vector3 colliderOffset = new Vector3(0.24f, 0f, 0f);
    public LayerMask groundLayer;

    [Space]

    [Header("Movimentamento")]
    public float velocidade = 10f;
    private bool direita = true;
    public bool puloDuplo = true;
    
    [Space]

    [Header("Dash")]
    public float dashspeed;
    public float cdDash = 1.5f;
    public float cdDasht = 0;

    [Space]

    [Header("Componentes")]
    //public ParticleSystem dusts;
    public GameObject cavera;
    public GameObject projetil;
    public GameObject fundo;
    public GameObject fundoR;
    public GameObject overworld;
    public GameObject overworldR;
    public GameObject phanto;
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public Animator animado;
    public Animator animadoR;
    public CapsuleCollider2D hitbox;
    public CapsuleCollider2D hitbox2;
    [Space]

    [Header("Mecanicas")]
    public float fallMult;

    private Transform bix;
    private bool c = false;
    public float lowJumpMult;
    public int puloss = 1;
    public float pulao;
    public static bool dead = false;

    [Header("cooldowns")]
    float cooldown = 0.4f;
    float cooldowntimer = 0f;



    

    void Start(){
        bix = GetComponent<Transform>(); //ESQUECI OQ É ISSO MAS TA AI
        
        
    }
    private void Awake()
    {
        ceifado = false;
        dead = false;
        rb.gravityScale = 3;
    }

    void Update(){
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        veloX = rb.velocity.x;
        veloY = rb.velocity.y;
        if (ceifado == false)
        {
            cdPassos();
            onGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundLayer) || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundLayer);

            if (dead == true) //QUANDO TA MORTO
            {
                dash();
                puloMorto();
                overworldR.SetActive(true);
                phanto.SetActive(true);
                sr.enabled = false;
                hitbox.isTrigger = true;
                fundoR.SetActive(true);
                fundo.SetActive(false);
                hitbox2.enabled = true;
                overworld.SetActive(false);
            }
            else               //QUANDO TA VIVO
            {

                puloVivo();
                overworldR.SetActive(false);
                overworld.SetActive(true);
                phanto.SetActive(false);
                sr.enabled = true;
                hitbox.isTrigger = false;
                fundoR.SetActive(false);
                fundo.SetActive(true);
                hitbox2.enabled = false;

            }
        }
        if (ceifado)
        {
            //dusts.Play();
            HUD.instance.crossfadeStart();
            Invoke("sumir", 0.55f);
            animadoR.SetTrigger("rip");
            Debug.Log("animacao de morte");
            hitbox.enabled = false;
            hitbox2.enabled = false;
            rb.gravityScale = 0;
            rb.velocity = new Vector3(0, 0, 0);
            Invoke("restart", 3f);

            
        }
    }
    void FixedUpdate()
    {
        if (ceifado == false)
        {
            if (dead == false)// TA VIVO
            {
                moverseVivo();
            }
            else // N TA
            {
                moverseMorto();
            }
        }
    }
    void moverseVivo()
    {
        Vector3 moverse = new Vector3(Input.GetAxis("Horizontal"),0f, 0f);
        transform.position += moverse * Time.deltaTime * velocidade;

        if (Input.GetAxis("Horizontal") == 0)
        {
            animado.SetBool("aAndar", false);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {

            animado.SetBool("aAndar", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            direita = true;
        }

        if (Input.GetAxis("Horizontal") < 0)

        {

            animado.SetBool("aAndar", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            direita = false;
        }

    }
    void moverseMorto()
    {
        Vector3 moverse = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += moverse * Time.deltaTime * velocidade;

        if (Input.GetAxis("Horizontal") == 0)
        {
            animado.SetBool("aAndar", false);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {

            animado.SetBool("aAndar", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            direita = true;
        }

        if (Input.GetAxis("Horizontal") < 0)

        {

            animado.SetBool("aAndar", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            direita = false;
        }
    }





    void puloVivo()
    {
        if (onGround)
        {
            animado.SetBool("aPular", false);
        }
        else
        {
            animado.SetBool("aPular", true);
        }
        if (Input.GetButtonDown("Jump") && onGround /*puloss > 0*/)
        {

            soundmanagero.PlaySound("sPulo");
            if (rb.velocity.y < 0)
            {
                rb.AddForce(new Vector2(0f, pulao + -rb.velocity.y), ForceMode2D.Impulse);
                //puloss -= 1;

            }
            else
            {
                rb.AddForce(new Vector2(0f, pulao - rb.velocity.y), ForceMode2D.Impulse);
                //puloss -= 1;


            }

        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMult - 1) * Time.deltaTime;

        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMult - 1) * Time.deltaTime;

        }
    }
    void puloMorto()
    {
        if (onGround)
        {
            puloDuplo = true;
            animado.SetBool("aPular", false);
        }
        else
        {
            
            animado.SetBool("aPular", true);
        }


        if (Input.GetButtonDown("Jump") && onGround || Input.GetButtonDown("Jump") && puloDuplo)
        {
            soundmanagero.PlaySound("sPulo");
            if (rb.velocity.y < 0)
            {
                rb.AddForce(new Vector2(0f, pulao + -rb.velocity.y), ForceMode2D.Impulse);
                puloss -= 1;

            }
            else
            {
                rb.AddForce(new Vector2(0f, pulao - rb.velocity.y), ForceMode2D.Impulse);
                puloss -= 1;


            }
            if(onGround == false)
            {
                puloDuplo = false;
            }

        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMult - 1) * Time.deltaTime;

        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMult - 1) * Time.deltaTime;

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        //if (collision.gameObject.layer == 8)
        //{ 
        //  puloss = 1;
        //  animado.SetBool("aPular", false);
            
        //}
        //else if (collision.gameObject.layer == 12)
        //{
        //    puloss = 1;
        //    animado.SetBool("aPular", false);

        //}



        if (collision.gameObject.layer == 9) //quando rela na flor
        {

            dead = false;
        }



        if (collision.gameObject.layer == 10) //quando rela no espinho
        {
            if (rb.velocity.y < 0)
            {
                rb.AddForce(new Vector2(0f, pulao + 5 + -rb.velocity.y), ForceMode2D.Impulse);
                

            }
            else
            {
                rb.AddForce(new Vector2(0f, pulao + 5 - rb.velocity.y), ForceMode2D.Impulse);
                


            }
            Instantiate(projetil, transform.position, transform.rotation);
            //Instantiate(cavera, transform.position, transform.rotation);
            dead = true;
            HUD.instance.bangar();
        }


        
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //if(dead == false)
        //{
        //    if (collision.gameObject.layer == 8)
        //    {
        //    puloss = 0;
        //    animado.SetBool("aPular", true);
        //    }
        //}
        //else
        //{
        //    if (collision.gameObject.layer == 8)
        //    {
        //        puloss = 1;
        //        animado.SetBool("aPular", true);
        //    }
        //}
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.layer == 9)
        {
            dead = false;
        }


        if (trig.gameObject.tag == "upboost")
        {
            rb.velocity = Vector2.up * 30;
            soundmanagero.PlaySound("boost");
        }

        if (trig.gameObject.tag == "rightboost")
        {
            rb.velocity = Vector2.right * 30;
            soundmanagero.PlaySound("boost");
        }

        if (trig.gameObject.tag == "leftboost")
        {
            rb.velocity = Vector2.left * 30;
            soundmanagero.PlaySound("boost");
        }

        if (trig.gameObject.tag == "downboost")
        {
            rb.velocity = Vector2.down * 30;
            soundmanagero.PlaySound("boost");
        }

    }
    void agachamento()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            bix.localScale = new Vector3(3.5f, 2.4f, 1f);
            velocidade -= 5;
            c = true;

        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            bix.localScale = new Vector3(3.5f, 3.5f, 1f);
            velocidade += 5;
            c = false;
        }



    }
    void dash()
    {
        if (cdDasht > 0)
        {
            cdDasht -= Time.deltaTime;
        }
        if (cdDasht < 0)
        {
            cdDasht = 0;
        }
        
        if(cdDasht < 1.1 && cdDasht > 1.0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }


        if (Input.GetKey(KeyCode.LeftShift) && c == false && direita == true && cdDasht == 0)
        {

            //rig.AddForce (Vector2.right * dashspeed, ForceMode2D.Impulse);
            rb.AddForce(new Vector2(dashspeed, 0f), ForceMode2D.Force);


            /* rig.velocity = Vector2.right * dashspeed; */
            soundmanagero.PlaySound("dash");
            cdDasht = cdDash;
            
        }
        if (Input.GetKey(KeyCode.LeftShift) && c == false && direita == false && cdDasht == 0)
        {

            rb.AddForce(new Vector2(-dashspeed, 0f), ForceMode2D.Force);

            /* rig.velocity = Vector2.left * dashspeed; */
            soundmanagero.PlaySound("dash");
            cdDasht = cdDash;
            
        }

    }
    void OnCollisionStay2D(Collision2D collision)
    {
        

        if (collision.gameObject.layer == 8 && Input.GetAxisRaw("Horizontal") != 0 && cooldowntimer == 0 && dead == false)
        {
            soundmanagero.PlaySound("walk");
            cooldowntimer = cooldown;
        }
    }

    void cdPassos()
    {
        
        if (cooldowntimer > 0)
        {
            cooldowntimer -= Time.deltaTime;
        }
        if (cooldowntimer < 0)
        {
            cooldowntimer = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + Vector3.down * groundLength);
        Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + Vector3.down * groundLength);
    }
    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void sumir()
    {
        phanto.SetActive(false);
    }



}
    
    
    
    /* void tiro(){
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
      if(Time.time -ultimoTiro >= recarga){
                if(direita == true){
          Instantiate (projetil, -transform.position, transform.rotation);
              ultimoTiro = Time.time;
                    }
                    else{
                        Instantiate (projetil, -transform.position, transform.rotation);
              ultimoTiro = Time.time;

                    }

            }
  }
     } */


