using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmanagero : MonoBehaviour
{
    public static AudioClip sPulo, walk, sHit, rar, dash, boost; /*sLand,  sDie, Grab, nota, tiro;*/
    static AudioSource asr;

    void Start()
    {
        sPulo = Resources.Load<AudioClip>("sPulo");
        walk = Resources.Load<AudioClip>("walk");
        //sLand = Resources.Load<AudioClip>("sLand");
        sHit = Resources.Load<AudioClip>("sHit");
        rar = Resources.Load<AudioClip>("rar");
        dash = Resources.Load<AudioClip>("dash");
        //sDie = Resources.Load<AudioClip>("sMorreu");
        boost = Resources.Load<AudioClip>("boost");
        //Grab = Resources.Load<AudioClip>("Grab");
        //nota = Resources.Load<AudioClip>("nota");
        //tiro = Resources.Load<AudioClip>("tiro");


        asr = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "sPulo":
                asr.PlayOneShot(sPulo);
                break;
            case "walk":
                asr.PlayOneShot(walk);
                break;
            case "sHit":
                asr.PlayOneShot(sHit);
                break;
            case "rar":
                asr.PlayOneShot(rar);
                break;
            case "dash":
                asr.PlayOneShot(dash);
                break;
            case "boost":
                asr.PlayOneShot(boost);
                break;
                //case "Grab":
                //    asr.PlayOneShot(Grab);
                //    break;
                //case "nota":
                //    asr.PlayOneShot(nota);
                //    break;
                //case "tiro":
                //    asr.PlayOneShot(tiro);
                //    break;
            //case "sLand":
            //    asr.PlayOneShot(sLand);
            //    break;
            //case "sMorreu":
            //    asr.PlayOneShot(sDie);
            //    break;
        }
    }
}
