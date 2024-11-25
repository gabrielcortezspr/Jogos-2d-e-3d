using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;
using System.Dynamic;



public class movimentamento : MonoBehaviour
{
    public Vector2 fov;
    [Header("estatisticas")]
    
    
    bool tomanouma;
    public int potions;
    public static int critRate = 40;
    public int dano;
    public int ultimatedmg;
    public float managauge;
    public static float vida ;
    public int vidaMax;
    public static float mana;
    public float dashspeed;
    public float recarga;
    public float cdDash = 1.5f;
    public float velocidade;
    public float jumpSpeed;
    public float manaregeneration;
    public float manaconsume;
    public int maxPots;
    float stun;
    bool stunned = false;
    //public float kb;
    bool kbright;



    [Header("componentes")]
    public AudioSource fogoLoop;
    
    public ParticleSystem fogo;
    public GameObject textinho;
    public GameObject textinholvup;
    public Vector3 detectionRange;
    Vector3 BasedetectionRange;
    public ParticleSystem dust;
    public GameObject projetil;
    public AudioSource falecido;
    public Rigidbody2D rb;
    Animator animado;
    public bool dupra = true;
    public static bool atirando = false;

    
    
    
    public float yspd;
    public float xspd;
    
    float cdDasht = 0;
    public float fallMult = 1f;
    public float lowJumpMult = 7f;
    
    public int puloss;
    public bool tapulando;
    [HideInInspector]
    public bool direita ;
    
    bool isDashing = false;
    [Header("detector")]
    float connpenza = 0.16f;
    public GameObject checkpoint1;
    //public GameObject checkpoint2;
    float compensa = 0;
    public LayerMask groundLayer;
    public Vector3 colliderOffset = new Vector3(0.24f, 0f, 0f);
    public Vector3 colliderOffset2;
    public float groundLength = 1.1f;
    public bool onGround = false;
    bool kappa = true;
        float nerf;
        bool nerfado = false;
    [Header("novo")]
    [Space]
    
    
    public float linearDrag = 4f;
    
    
    
    float baseDrag;
    public float friccao;
    [Header("stand")]
    public bool haveStand;
    public bool haveDash;
    public bool haveDblJmp;
    public bool haveUlt;
    public int xp;
    public int lvl;
    public int str;
    public int spd;
    public int range;
    public int def;
    public int sp;
    [Header("BossPowers")]
    public bool bp_bolha;
    public bool bolha;
    public GameObject bolhaSprite;
    public ParticleSystem particlBbl;
    [Header("debuffs")]
    public float ignite;
    public float silence;
    public float veneno;
    public float chokk;
    public ParticleSystem choquinho;
    public GameObject Shkxplsion;
    




    float pulobase;
    void Start(){
        BasedetectionRange = detectionRange;
        pulobase = jumpSpeed;
        if(bolhaSprite != null)
        {
            bolhaSprite.SetActive(false);
        }
        rb = GetComponent<Rigidbody2D>();
        animado = GetComponent<Animator>();
        maxPots = PlayerPrefs.GetInt("pots");
        potions = maxPots;
        falecido = GetComponent<AudioSource>();
        baseSpeed = velocidade;
        baseDrag = rb.drag;
        xp = PlayerPrefs.GetInt("xp");
        lvl = PlayerPrefs.GetInt("lvl");
        sp = PlayerPrefs.GetInt("sp");
        str = PlayerPrefs.GetInt("str");
        spd = PlayerPrefs.GetInt("spd");
        range = PlayerPrefs.GetInt("range");
        def = PlayerPrefs.GetInt("def");
        if (PlayerPrefs.GetInt("checkpoint") == 0)
        {
            
        }else if(PlayerPrefs.GetInt("checkpoint") == 1)
        {
            if(checkpoint1 != null)
            {
            transform.position = checkpoint1.transform.position;
                
            }
        }

        if (FindObjectOfType<pontuacao>().easy)
        {
            vidaMax = 300;
        }
        else if(pontuacao.hardware)
        {

        vidaMax = 75;
        }
        vidaMax += (def * 5);
        vida = vidaMax;
        mana = 0;
        switch (PlayerPrefs.GetInt("range"))
        {
            case 0: detectionRange = BasedetectionRange;
                break;
            case 1: detectionRange = new Vector2(detectionRange.x + 3, detectionRange.y + 3);
                break;
            case 2: detectionRange = new Vector2(detectionRange.x + 5, detectionRange.y + 5);
                break;
            case 3: detectionRange = new Vector2(detectionRange.x + 8, detectionRange.y + 8) ;
                break;

        }
        
        
        direita = true;
        puloss = 1;
        
        if(PlayerPrefs.GetInt("stand") == 2)
        {
            haveDash = true;
            haveDblJmp = true;
            haveStand = true;
            haveUlt = true;

        }
            else if (PlayerPrefs.GetInt("stand") == 1)
                {
                    haveDash = false;
                    haveDblJmp = true;
                    haveStand = true;
                    haveUlt = true;
                }
                else if (PlayerPrefs.GetInt("stand") == 0)
                    {
                        haveDash = false;
                        haveDblJmp = false;
                        haveStand = false;
                        haveUlt = false;
                    }

        
       
    }
    float baseSpeed;
    
    float pernas;
    bool onWater;
    [HideInInspector]
    public float chaostate;

    
    
    void Update()
    {
        
        if (vida <= 0)
        {
            pontuacao.instance.morrestes();
            soundmanagero.PlaySound("sMorreu");
            Destroy(gameObject);
        }
        if (vida > vidaMax)
        {
            vida = vidaMax;
        }
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            str = 40;
            def = 30;
            vidaMax = 50000;
            vida = 50000;
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            potions += 10;
        }

        float danoDoUgnite;
        danoDoUgnite = 10 - Mathf.Abs( rb.velocity.x);
        if(ignite > 0){
            if(danoDoUgnite < 0)
            {
            vida -= Time.deltaTime * 2;

            }
            else
            {
                vida -= Time.deltaTime * danoDoUgnite;
            }
            ignite -= Time.deltaTime;
            if (!fogoLoop.isPlaying)
            {
            fogoLoop.Play();

            }
            fogo.emissionRate = ignite * 5;
        }
        else
        {
            if (fogoLoop.isPlaying)
            {

            fogoLoop.Stop();
            }
            fogo.emissionRate = 0;
        }
        onGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundLayer) || Physics2D.Raycast(transform.position + colliderOffset2, Vector2.down, groundLength, groundLayer);
        managauge = mana;
        if(mana > 20)
        {
            mana = 20;
        }
        float diferenca;
        diferenca = Vector2.Distance(transform.position, FindObjectOfType<grande>().transform.position);
        int reducao;
        if(diferenca > 18)
        {
            reducao = 8;
        }else
        {
            reducao = 0;
        }
        int reducTotal = (int)((diferenca * 1.3f) + reducao);
        dano = Random.Range(30 + (str * 5) - reducTotal, 50 + (str * 2) - reducTotal);
        bool wasOnGround = onGround;
        //onGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundLayer) || Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundLayer);


        
        
        if(xp >= 100)
        {
            xp -= 100;
            soundmanagero.PlaySound("lvup");
            textinholvup.GetComponentInChildren<TextMeshPro>().color = Color.green;
            textinholvup.GetComponentInChildren<TextMeshPro>().text = "Level Up!!!";
            Instantiate(textinholvup, transform.position, Quaternion.identity);
            lvl += 1;
            FindObjectOfType<lvlUI>().Insta();
            sp += 1;
            
        }
        if (onGround)
        {
            compensa = connpenza;
            pernas = 0.25f;
            
        }
        if (!onGround && pernas >= 0)
            pernas -= Time.deltaTime;
        if (compensa > 0)
        {
            compensa -= Time.deltaTime;
        }
        if(compensa < 0)
        {
            compensa = 0;
        }
        if (stun > 0)
        {
            stun -= Time.deltaTime;
        }
        if(chokk > 0)
        {
            choquinho.Play();
        }
        if(chokk > 0 && onGround)
        {
            takedmg(chokk, 0, transform.position,0,0,true);
            
            stun += chokk * 0.3f;
            chokk = 0;
            soundmanagero.Som("shock");
            choquinho.Stop();
            GameObject sck = (GameObject)Instantiate(Shkxplsion, transform.position, Quaternion.identity);
            Destroy(sck, 1);
            
        }
        if(silence > 0)
        {
            silence -= Time.deltaTime * (1 + (def * 0.1f));
        }
        if(chaostate > 0)
        {
            chaostate -= Time.deltaTime;
        }
        if(veneno > 0)
        {
            veneno -= Time.deltaTime * (1 + (def * 0.3f));
            vida -= Time.deltaTime * (0.3f + (Mathf.Abs(rb.velocity.x) * 0.4f)
                );
            GetComponent<SpriteRenderer>().color = new Color(0.6f, 1, 0.6f, 1);
           
            

          
            
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (Input.GetAxisRaw("Vertical") < 0 && Input.GetMouseButtonDown(1) && onGround && mana > 2.5f && bp_bolha && !blg && !isDashing)
        {
            if(chaostate > 0)
            {
                if(mana > 7)
                {
                    StartCoroutine(Bubling());
                    return;
                }
                return;
            }
            StartCoroutine(Bubling());
        }
        
        if(stun <= 0)
        {
            stunned = false;
        }

        if (Input.GetKeyDown(KeyCode.R) && potions > 0 && !tomanouma || Input.GetKeyDown(KeyCode.E) && potions > 0 && !tomanouma)
        {
            StartCoroutine(potar());
        }
        if (tomanouma || onWater)
        {
            baseSpeed = velocidade * 0.3f;
        }
        else
        {
            baseSpeed = velocidade;
        }
        pulo();
        if (!tomanouma)
        {
        corrida();

        }
        yspd = rb.velocity.y;
        xspd = rb.velocity.x;
        if (!onWater)
        {
        if(rb.velocity.y <= -28f){
            rb.gravityScale = 0;
        }
        else if(!onWater){
            rb.gravityScale = 6;
        }

        }
        if(Input.GetKey(KeyCode.X)){
            
            vida -= 1000;
            
            
        }
        
    }
    
   
    
    

    void FixedUpdate (){
        
        //if(Input.GetAxis("Horizontal") == 0 && onGround)
        //{
        //    rb.drag = linearDrag;
        //}else rb.drag = baseDrag;

        if (!stunned)
        {

            move();
        }
        if(!onGround && compensa <= 0)
        {
            animado.SetBool("aPular", true);
        }
        else
        {
            animado.SetBool("aPular", false);
        }
        
        
        
    }
    
    void move()
    {

        //float moverse = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector2(moverse * velocidade, rb.velocity.y);

        Vector3 moverse = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
       
        float potencia = moverse.x * baseSpeed * Time.deltaTime;
        Vector2 vecto = new Vector2(potencia, 0);
        rb.AddForce(vecto);

        if (Input.GetAxis("Horizontal") == 0)
        {
            animado.SetBool("aAndar", false);
            
        }
        

        if (Input.GetAxis("Horizontal") > 0)
        {

            animado.SetBool("aAndar", true);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            direita = true;
        }

        if (Input.GetAxis("Horizontal") < 0)

        {

            animado.SetBool("aAndar", true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            direita = false;
        }


    }

    IEnumerator potar()
    {
        tomanouma = true;
        animado.SetBool("aPotar", true);
        yield return new WaitForSeconds(0.1f);
        
        vida += 10 + (def);
        potions -= 1;
        yield return new WaitForSeconds(0.2f);
        
        vida += 10 + (def);
        yield return new WaitForSeconds(0.16f);
        soundmanagero.PlaySound("gole");
        vida += 10 + (def);
        animado.SetBool("aPotar", false);
        tomanouma = false;

    }
    
    //void manaregen()
    //{
    //    if (mana < 0.3)
    //    {
    //        mana += 0.3f;
    //        nerf = 1.5f;
    //    }
    //    if(nerf > 0)
    //    {
    //        nerf -= Time.deltaTime;
    //        nerfado = true;
    //    }
    //    if (nerf < 0)
    //    {
    //        nerf = 0;
    //        nerfado = false;
            
    //    }
        
    //    if (mana < 20 && !nerfado)
    //    {

    //        mana += Time.deltaTime * manaregeneration;
    //    }
    //}
    public void knockback(float direcao, float kb)
    {
        if (kb <= 0)
        {
            return;
        }
        float kb2;
        kb2 = kb * 2.7f;
        Vector2 veto = new Vector2(kb2 * direcao, 10f + (kb2 * 0.1f));
        rb.AddForce(veto, ForceMode2D.Impulse);
        //rb.velocity = new Vector2(rb.velocity.x + (kb * direcao), 5f + (kb*0.1f));
    }
    void pulo()
    {
        
        if (onGround || compensa > 0)
        {
            dupra = true;
        }


        if (Input.GetButtonDown("Jump") && onGround || Input.GetButtonDown("Jump") && compensa > 0 || Input.GetButtonDown("Jump") && dupra && haveDblJmp && silence <= 0)
        {


            if (rb.velocity.y < 0)
            {
                rb.AddForce(new Vector2(0f, jumpSpeed + -rb.velocity.y), ForceMode2D.Impulse);


            }
            else
            {
                rb.AddForce(new Vector2(0f, jumpSpeed - rb.velocity.y), ForceMode2D.Impulse);



            }
            if (!onGround)
            {
                dupra = false;
            }

        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMult - 1) * Time.deltaTime;

        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump") && pernas > 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMult - 1) * Time.deltaTime;

        }


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            
            puloss = 2;
            
            
        }
        
        if(collision.gameObject.layer == 9)
        {
            takedmg(dano + 319251, 0, transform.position);
        }
        if (collision.gameObject.name.Contains("skulltrain"))
        {
            this.transform.parent = collision.transform;
        }
        if (collision.gameObject.layer == 11 && rb.velocity.y <= 0){
            soundmanagero.PlaySound ("nota");
            rb.AddForce(new Vector2(0f, 30f), ForceMode2D.Impulse);
        }
        if (collision.gameObject.tag == "victory")
        {
            if (haveUlt)
            {
                standpwr = 1;
            }
            if (haveDash)
            {
                standpwr = 2;
            }
            PlayerPrefs.SetInt("stand", standpwr);
            PlayerPrefs.SetInt("pots", maxPots);
            PlayerPrefs.SetInt("xp", xp);
            PlayerPrefs.SetInt("sp", sp);
            PlayerPrefs.SetInt("lvl", lvl);
           
            soundmanagero.PlaySound("tiro");
            
            

            
        }
    }
    public int standpwr;
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            
            puloss = 1;
            
        }
        if (collision.gameObject.name.Contains("skulltrain"))
        {
            this.transform.parent = null;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 4)
        {
            rb.gravityScale = 6;
            jumpSpeed = pulobase;
            
            onWater = false;

        }
    }
    void OnTriggerEnter2D(Collider2D trig){
        if(trig.gameObject.layer == 4)
        {
            rb.gravityScale = 0.05f;
            jumpSpeed = pulobase * 0.7f;
           
            onWater = true;
        }
        if(trig.gameObject.tag == "stando"){
            soundmanagero.PlaySound ("sMorreu");
            pontuacao.instance.morrestes();
            Destroy(gameObject);
            
        }
        if (trig.gameObject.tag == "convL"){
            
            rb.AddForce(new Vector2(-dashspeed, 0f), ForceMode2D.Impulse);
        }
        if (trig.gameObject.name.Contains("pot"))
        {
            potions += 1;
            maxPots += 1;
            soundmanagero.PlaySound("Grab");
            Destroy(trig.gameObject);
        }
        
        if (trig.gameObject.CompareTag("spike"))
        {
            takedmg(45,0,transform.position);
        }
    }
    
        void corrida(){
        if (cdDasht > 0){
            cdDasht -= Time.deltaTime;
        }
        if (cdDasht < 0){
            cdDasht = 0;
        }
        if (cdDasht < 1.2 && cdDasht > 1.1)
        {
            isDashing = false;
            
            //kappa = true;
        }

        if (Input.GetKeyDown (KeyCode.LeftShift) && Input.GetAxisRaw("Horizontal") != 0 && cdDasht == 0 && haveDash && silence <= 0)
        {
            float direcao = Input.GetAxisRaw("Horizontal");
            cdDasht = cdDash;
            CreateDust();
            isDashing = true;
            
            //kappa = false;
            if (isDashing)
            {
                dash(direcao);

            }
        }
        
        //if(Input.GetKey(KeyCode.LeftShift)&& c == false && direita == true && cdDasht == 0){
           
        //   //rig.AddForce (Vector2.right * dashspeed, ForceMode2D.Impulse);
        //   rig.AddForce(new Vector2(dashspeed, 0f), ForceMode2D.Impulse);
           
        //   /* rig.velocity = Vector2.right * dashspeed; */
        //   cdDasht = cdDash;
        //   CreateDust();           
        //}
        //if(Input.GetKey(KeyCode.LeftShift)&& c == false && direita == false && cdDasht == 0){
            
        //    rig.AddForce(new Vector2(-dashspeed, 0f), ForceMode2D.Impulse);
            
        //    /* rig.velocity = Vector2.left * dashspeed; */
        //    cdDasht = cdDash;
        //    CreateDust();
        //}
     
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("venenos"))
        {
            veneno += Time.deltaTime * 3;
            vida -= Time.deltaTime * 3;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "spike")
        {

            //textinho.text = "45";
            //Instantiate(textinho, transform.position, Quaternion.identity);

            takedmg(45, 0, collision.transform.position);



        }
    }
    void CreateDust(){
        dust.Play();
        
    }
    void dash(float x)
    {
        
        if(x > 0)
        {

            rb.velocity = new Vector2(0, rb.velocity.y);
            //rb.velocity += Vector2.right * dashspeed;
            rb.AddForce(new Vector2(dashspeed, 0f), ForceMode2D.Impulse);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            //rb.velocity += Vector2.left * dashspeed;
            rb.AddForce(new Vector2(-dashspeed, 0f), ForceMode2D.Impulse);
        }
    }
    public bool imune;
    IEnumerator iframes(float frams)
    {
        imune = true;
        
        yield return new WaitForSeconds(frams);
       
       
        imune = false;

    }
    bool blg;
    IEnumerator Bubling()
    {
        blg = true;
        tomanouma = true;
        soundmanagero.Som("standed");
        if(chaostate > 0)
        {
            mana -= 5;
            chaostate += 2;
        }
        mana -= 2.5f;
        chaostate += 3;
        FindObjectOfType<grande>().particula.Play();
        FindObjectOfType<grande>().transform.position = transform.position + Vector3.up * 2;
        FindObjectOfType<grande>().Travado = true;
        particlBbl.Play();
        yield return new WaitForSeconds(0.3f);
        soundmanagero.Som("tufao");
        bolhaSprite.SetActive(true);
        bolha = true;
        FindObjectOfType<grande>().Travado = false;
        blg = false;
        tomanouma = false;
    }
    public void takedmg(float dmg, float kb, Vector3 posicao, float silence = 0, float iF = 0.2F, bool irreferivel = false)
    {
        if (!irreferivel)
        {
            if (imune)
            {
                return;
            }
            if(bolha && dmg <= 15)
            {
                textinho.GetComponentInChildren<TextMeshPro>().color = Color.gray;
                textinho.GetComponentInChildren<TextMeshPro>().text = "Imune!!!";
                Vector3 veto = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
                soundmanagero.Som("bolha", 2);
                Instantiate(textinho, veto, Quaternion.identity);
                return;
            }
        }
        if (bolha)
        {
            dmg -= 15;
            bolha = false;
            bolhaSprite.SetActive(false);
            soundmanagero.Som("pop", 1.5f);
        }
        StartCoroutine(iframes(iF));
        int dados;
        dados = Random.Range(0, 3);
        if (dados > 1)
        {
            soundmanagero.PlaySound("uuhh");
        }
        else
        {
            soundmanagero.PlaySound("oof");
        }
        Vector3 pos = FindObjectOfType<movimentamento>().transform.position;

        //soundmanagero.PlaySound("sHit");
        textinho.GetComponentInChildren<TextMeshPro>().color = Color.red;
        int idm;
        idm = (int)dmg;
        textinho.GetComponentInChildren<TextMeshPro>().text = idm.ToString();
        
        Instantiate(textinho, transform.position, Quaternion.identity);
        if(silence > 0)
        {
            FindObjectOfType<movimentamento>().silence += silence;
            textinho.GetComponentInChildren<TextMeshPro>().color = Color.magenta;
            FindObjectOfType<grande>().particula.Play();
            textinho.GetComponentInChildren<TextMeshPro>().text = "Silenciado " + silence.ToString() + "s!!!";
            Vector3 veto = new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z);
            soundmanagero.PlaySound("slc");
            Instantiate(textinho, veto, Quaternion.identity);

        }
        if(posicao.x < transform.position.x)
        {
        knockback(1, kb);

        }
        else
        {
            knockback(-1, kb);
        }
        mana += dmg * .1f;
        vida -= dmg;
        
        

    }
    
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + Vector3.down * groundLength);
        Gizmos.DrawLine(transform.position + colliderOffset2, transform.position + colliderOffset2 + Vector3.down * groundLength);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * detectionRange.y);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * detectionRange.x);
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * fov.y);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * fov.y);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * fov.x);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * fov.x);
    }
    private void OnDestroy()
    {
        contador.morreu();
        
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





}
