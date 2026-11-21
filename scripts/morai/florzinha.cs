using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class florzinha : MonoBehaviour
{
    
    public ParticleSystem boom;
    SpriteRenderer sr;
    PolygonCollider2D col;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<PolygonCollider2D>();
    }
    private void Update()
    {
        if(nag.dead == false)
        {
            sr.enabled = false;
            col.enabled = false;
        }
        else
        {
            sr.enabled = true;
            col.enabled = true;
        }
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.tag == "Player")
        {
            boom.Play();
        }
    }
    
}
