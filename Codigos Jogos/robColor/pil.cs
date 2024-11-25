using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pil : MonoBehaviour
{
    public float valor;
    public bool bigpilha;
    public ParticleSystem pix;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Loop1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Loop1()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0.1f);
        yield return new WaitForSeconds(1.2f);
        StartCoroutine(Loop2());
    }
    IEnumerator Loop2()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -0.1f);
        yield return new WaitForSeconds(1.2f);
        StartCoroutine(Loop1());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Chin.bateria += valor;
            if (bigpilha)
            {
                Chin.pilhado = true;
                Chin.pilhadocd = 3f;
            }
            pix.Play();
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject,5f);
        }
    }
}
