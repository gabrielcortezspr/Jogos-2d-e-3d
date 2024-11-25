using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public bool lobby;
    public Transform sonic;
    public float cameraDistance = 30.0f;


    //private AudioSource[] musiquinhas;
    public GameObject barra;
    public GameObject contination;
    public AudioSource bgm;
    public AudioSource bgm2;
    public AudioSource bossmusic;
    
    public int musica;
    
    
    public AudioSource falecido;

    void Update ()
    {
        setvolumes();
        
        if (lobby)
        {
            return;
        }
        
        if(sonic == null && !lobby){
            bgm.pitch = 0.55f;
            bgm2.pitch = 0.55f;
            bossmusic.pitch = 0.55f;
           
            falecido.enabled = true;
            
            
            
        }
        switch (musica)
        {
            case 0:
                bgm.enabled = true;
                bgm2.enabled = false;
                bossmusic.enabled = false;
                
                break;
            case 1:
                bgm.enabled = false;
                bgm2.enabled = true;
                bossmusic.enabled = false;
                
                break;
            case 2:
                bgm.enabled = false;
                bgm2.enabled = false;
                bossmusic.enabled = true;
                
                break;
            

        }

        
            //if (FindObjectOfType<miniboss1>().triggered)
            //{
            //barra.SetActive(true);
            //jojo.enabled = false;
            //bossmusic.enabled = true;
            //}
        

            //if(FindObjectOfType<miniboss1>().enraged == 3)
            //{
            //jojo.enabled = false;
            //bossmusic.enabled = false;
            //bossbrabo.enabled = true;

            //}
        
        
    }
    void setvolumes()
    {
        
        bgm.volume = pontuacao.somMusica;
        
        if(lobby)
        {
            return;
        }
        
        falecido.volume = pontuacao.somMusica;
        bossmusic.volume = pontuacao.somMusica;
        bgm2.volume = pontuacao.somMusica;
        
    }
    void Awake ()
    {
        bgm.enabled = true;
        
        if (lobby)
        {
            return;
        }
        
        
        
        
        
    }
    bool paro;
    void FixedUpdate ()
    {
        if (lobby)
        {
            return;
        }
        //if(transform.position.x > 500 && transform.position.y < -180)
        //{
        //    bgm.enabled = false;
        //    continua.enabled = true;
        //    contination.SetActive(true);
        //    paro = true;
            

        //}
        //else
        //{
            
        //    paro = false;
        //}
        GetComponent<UnityEngine.Camera>().orthographicSize = cameraDistance;  
        if(sonic == null)
        {
            return;
        }
        transform.position = new Vector3(sonic.position.x, sonic.position.y, transform.position.z);

    }
    
}
