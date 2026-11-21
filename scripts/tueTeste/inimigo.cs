using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class inimigo : MonoBehaviour
{
    [Header ("stats")]
    public float vidaMax;
    public float dano;
    public float iframe;
    public float knockback;
    public float kbResist;
    public int defesa;
    public float damageReduction;
    public int xp;


    [Header("esseincial")]
    public GameObject textinho;
    public Vector3 detectionRange;

    [Header("opcionais")]
    public hpInimigo barra;
    public bool dA; // death animation
    public GameObject debris;
    [Header ("internos")]
    public bool inv;
    [HideInInspector]public bool knocked;
    
    





    
    public bool inRange;
    public float vidaAtual;
    
   
    public float framt;
    public bool boss;
    


    private void Start()
    {
        if (pontuacao.hardware)
        {
            vidaAtual = vidaMax * 2;
            
        }
        else
        {

        vidaAtual = vidaMax;
        }

    }
    public GameObject key;
    private void Update()
    {
        if(framt > 0)
        {
            framt -= Time.deltaTime;
        }
        if(framt < 0)
        {
            framt = 0;
        }


        //slid.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);
        if (!boss && barra) { 
        barra.settleHP(vidaAtual, vidaMax);
        }

        if (vidaAtual < 0)
        {
            
            if (dA)
            {
                GetComponent<aiBasica>().enabled = false;
                GetComponent<CapsuleCollider2D>().enabled = false;
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                GetComponent<Animator>().SetTrigger("dead");
            }
            else
            {
                if (boss)
                {
                    soundmanagero.PlaySound("firewall");
                    Instantiate(key, transform.position, Quaternion.identity);
                }
                else
                {
                    soundmanagero.PlaySound("kill");

                }
                
                FindObjectOfType<movimentamento>().xp += xp;
                if(debris != null)
                {
                    Instantiate(debris, transform.position, Quaternion.identity);
                    
                    Destroy(gameObject);
                }
                Destroy(gameObject);

            }
        }
        if(FindObjectOfType<movimentamento>() == null)
        {
            return;
        }
        if (FindObjectOfType<movimentamento>().transform.position.x < transform.position.x + detectionRange.x && FindObjectOfType<movimentamento>().transform.position.x > transform.position.x - detectionRange.x)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }
    }
    public void destruicao()
    {
        if (boss)
        {
            soundmanagero.PlaySound("firewall");
        }
        else
        {
            soundmanagero.PlaySound("kill");

        }
        if(FindObjectOfType<movimentamento>() != null)
        {

        FindObjectOfType<movimentamento>().xp += xp;
        }
        Destroy(gameObject);
    }
    //public void settleHP(float act, float max)
    //{
    //    slid.gameObject.SetActive(act < max);
    //    slid.value = act;
    //    slid.maxValue = max;
    //}
    private void FixedUpdate()
    {
        
    }

    public void takedmg(float dmg, bool crit, Vector3 pos, string hitmarketing = "mark", bool mana = true,bool ignorante = false)
    {
        float danoInicial;
        float kb;
        danoInicial = dmg;
        if(kbResist < 0)
        {
            kb = 80 + Mathf.Abs(kbResist);
        }
        else
        {
            kb   = 80 - kbResist;

        }
        if (GetComponent<aiDeflecter>())
        {
            float defleter;
            defleter = Random.Range(1, 100);
            if (defleter < GetComponent<aiDeflecter>().deflection || GetComponent<aiDeflecter>().deflectConter > 0)
            {
                GetComponent<aiDeflecter>().deflectConter = GetComponent<aiDeflecter>().deflectedTimer;
                if (transform.position.x > FindObjectOfType<movimentamento>().transform.position.x)
                {
                    GetComponent<aiBasica>().rb.velocity = Vector2.zero;
                    GetComponent<aiBasica>().rb.AddForce(Vector2.left * 25, ForceMode2D.Impulse);
                }
                else if (transform.position.x < FindObjectOfType<movimentamento>().transform.position.x)
                {
                    GetComponent<aiBasica>().rb.velocity = Vector2.zero;
                    GetComponent<aiBasica>().rb.AddForce(Vector2.right * 25, ForceMode2D.Impulse);
                }
                int qual;
                qual = Random.Range(1, 3);
                switch (qual)
                {
                    case 1: soundmanagero.PlaySound("deflect1");
                        break;
                    case 2: soundmanagero.PlaySound("deflect2");
                        break;
                    case 3: soundmanagero.PlaySound("deflect3");
                        break;
                }
             
                
                return;
            }
        }
        if (!ignorante)
        {

            if (framt > 0 || inv)
            {
                return;
            }
        }
        soundmanagero.PlaySound(hitmarketing);
        
        
        framt = 0.015f;
        float reducao;
        reducao = dmg * (damageReduction * 0.01f);

        dmg -= reducao;
        dmg -= defesa;
        if(dmg < 1)
        {
            dmg = 1;
        }
        if (kb > 0 && GetComponent<Rigidbody2D>())
        {
            if (transform.position.x > FindObjectOfType<movimentamento>().transform.position.x)
            {
                StartCoroutine(nockar(kb));

            }
            else
            {
                StartCoroutine(nockar(-kb));

            }
        }
        if (mana)
        {
        movimentamento.mana += dmg * 0.005f;

        }
        if (dmg < danoInicial * 0.5f && !crit)
        {
            dmg = (int)dmg;
            textinho.GetComponentInChildren<TextMeshPro>().text = dmg.ToString();

            textinho.GetComponentInChildren<TextMeshPro>().color = Color.gray;
            GameObject prompt = (GameObject)Instantiate(textinho, pos, Quaternion.identity);
            prompt.GetComponentInChildren<TextMeshPro>().fontSize = textinho.GetComponentInChildren<TextMeshPro>().fontSize * 0.6f;
            vidaAtual -= dmg;
            OnTakeDMG(dmg);
            return;
        }
        if (crit)
        {
            dmg = dmg* 2;
            dmg = (int)dmg;
            textinho.GetComponentInChildren<TextMeshPro>().text = dmg.ToString();
            

            textinho.GetComponentInChildren<TextMeshPro>().color = new Color(1,0.5f,0,1);
            GameObject prompt = (GameObject)Instantiate(textinho, pos, Quaternion.identity);
            prompt.GetComponentInChildren<TextMeshPro>().fontSize = textinho.GetComponentInChildren<TextMeshPro>().fontSize * 1.2f;
            

            vidaAtual -= dmg;
            OnTakeDMG(dmg);
            return;
        }
        dmg = (int)dmg;
            textinho.GetComponentInChildren<TextMeshPro>().text = dmg.ToString();
            
            textinho.GetComponentInChildren<TextMeshPro>().color = Color.yellow;
            Instantiate(textinho, pos, Quaternion.identity);
            vidaAtual -= dmg;
        OnTakeDMG(dmg);


    }
    public void OnTakeDMG(float dmg)
    {
        if(GetComponent<lazerBeamer>() != null)
        {
            GetComponent<lazerBeamer>().gotHit = 1;
        }
        if (GetComponent<wormType>() != null)
        {
        GetComponent<wormType>().debito = dmg;
        }
        if(GetComponent<Kaotico>() != null)
        {
            if(GetComponent<Kaotico>().triggered == false)
            {
                GetComponent<Kaotico>().triggered = true;
                FindObjectOfType<camerafollow>().musica = 1;
                soundmanagero.Som("ameaca");
                GetComponent<Kaotico>().OnTakeDmg();
            }
        }
    }
    IEnumerator nockar(float kb)
    {
        knocked = true;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(kb, kb * 0.2f));
        yield return new WaitForSeconds(0.15f);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        knocked = false;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && dano > 0)
        {
            //textinho.text = dano.ToString();
            //Instantiate(textinho, transform.position, Quaternion.identity);
            FindObjectOfType<movimentamento>().takedmg(dano, knockback, transform.position, 0, iframe);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && dano > 0)
        {
            //textinho.text = dano.ToString();
            //Instantiate(textinho, transform.position, Quaternion.identity);
            FindObjectOfType<movimentamento>().takedmg(dano, knockback,transform.position, 0 , iframe);
            
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("venen"))
        {
            vidaAtual -= 1;



        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * detectionRange.x);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * detectionRange.y);
    }
}
