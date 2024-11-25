using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiroReto : MonoBehaviour
{
    public float escalamentoExplosão;
    public bool nVara;
    public GameObject explosao;
    public float delayInicial;
    public float speed;
    float defaultSpeed;
    public float delayDestruc;
   

    private void Start()
    {
        defaultSpeed = speed;
    }
    private void Update()
    {
        if(delayInicial > 0)
        {
            speed = 0;
            delayInicial -= Time.deltaTime;
            return;
        }
        speed = defaultSpeed;
        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }
    void TirarColisao()
    {
        if (GetComponent<BoxCollider2D>())
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        if (GetComponent<CapsuleCollider2D>())
        {
            GetComponent<CapsuleCollider2D>().enabled = false;
        }
        if (GetComponent<CircleCollider2D>())
        {
            GetComponent<CircleCollider2D>().enabled = false;
        }
        if (GetComponent<PolygonCollider2D>())
        {
            GetComponent<PolygonCollider2D>().enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("switch"))
        {
            if (FindObjectOfType<onOff>().cdt <= 0)
            {

                FindObjectOfType<onOff>().On = !FindObjectOfType<onOff>().On;
                FindObjectOfType<onOff>().cdt = 0.1f;
                soundmanagero.Som("switch", 1.6f);
                collision.GetComponent<Animator>().SetTrigger("s");
            }
        }
        if(collision.gameObject.layer == 8)
        {
            if (GetComponent<Rigidbody2D>())
            {
                if(explosao != null)
                {
                    GameObject area;
                    area = (GameObject)Instantiate(explosao, transform.position, Quaternion.identity);
                    if(escalamentoExplosão > 0)
                    {
                        area.transform.localScale = Vector3.one * escalamentoExplosão;
                    }
                }
                GetComponent<Rigidbody2D>().gravityScale = 0;
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                if(GetComponent<ParticleSystem>() != null)
                {
                    GetComponent<ParticleSystem>().Stop();
                }
                if (GetComponentInChildren<ParticleSystem>() != null)
                {
                    GetComponentInChildren<ParticleSystem>().Stop();
                }
                TirarColisao();
            }
            Destroy(gameObject, delayDestruc);
            if(GetComponent<fadeAway>() != null)
            {
                GetComponent<fadeAway>().manual = false;
            }
            defaultSpeed = 0;
            speed = 0;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            if (nVara)
            {
                if (GetComponent<Rigidbody2D>())
                {
                    if (explosao != null)
                    {
                        Instantiate(explosao, transform.position, Quaternion.identity);
                    }
                    GetComponent<Rigidbody2D>().gravityScale = 0;
                    GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                    if (GetComponent<ParticleSystem>() != null)
                    {
                        GetComponent<ParticleSystem>().Stop();
                    }
                    if(GetComponentInChildren<ParticleSystem>() != null)
                    {
                        GetComponentInChildren<ParticleSystem>().Stop();
                    }
                    TirarColisao();
                }
                Destroy(gameObject, delayDestruc);
                if (GetComponent<fadeAway>() != null)
                {
                    GetComponent<fadeAway>().manual = false;
                }
                defaultSpeed = 0;
                speed = 0;
            }
        }
    }
}
