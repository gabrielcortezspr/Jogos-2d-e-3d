using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaMatadora : MonoBehaviour
{
    public float velocidade;
    bool viravel = true;
    bool direita;
    public bool fogo = false;

    private void Awake()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5);
        
        Destroy(gameObject, 6);
        if (fogo)
        {
            viravel = false;
        }else viravel = true;

    }
    private void OnCollisionEnter2D(Collision2D jurupinga)
    {
        if(jurupinga.gameObject.layer == 8 && fogo)
        {
            Destroy(gameObject);
        }
        if(jurupinga.gameObject.layer == 8 && viravel)
        {
            if(FindObjectOfType<Chin>().transform.position.x > transform.position.x)
            {
                viravel = false;

                GetComponent<Rigidbody2D>().velocity = new Vector2(velocidade, GetComponent<Rigidbody2D>().velocity.y);
                direita = true;

            }else if (FindObjectOfType<Chin>().transform.position.x < transform.position.x)
            {
                viravel = false;

                GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidade, GetComponent<Rigidbody2D>().velocity.y);

                direita = false;
            }
        }
        if(jurupinga.gameObject.tag == "Player")
        {
            Gerente.Resetamento(0);
        }
    }
    private void Update()
    {
        if (direita && !viravel)
        {
            transform.eulerAngles -= new Vector3(0f, 0f, Time.deltaTime * 20);
        } else if (!viravel)
        {
            transform.eulerAngles += new Vector3( 0, 0 , Time.deltaTime * 20);
        }

    }
}
