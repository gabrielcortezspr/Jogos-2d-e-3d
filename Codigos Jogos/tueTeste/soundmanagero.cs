using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class soundmanagero : MonoBehaviour
{
    public static AudioClip sPulo, sLand, sHit, sDie, ari, Grab, nota, tiro,fire,mark,gxp,pistol,aero,aeroShot,stk,telefone,zipada,ss,oof,uuhh,standed,tufao,ultready, ultimato, launch, load, kill,canho
        , explo, jason, lvup;
    static AudioSource asr;
    float volume;
    void Start()
    {
        sPulo = Resources.Load<AudioClip> ("sPulo");
        sLand = Resources.Load<AudioClip> ("sLand");
        sHit = Resources.Load<AudioClip> ("sHit");
        sDie = Resources.Load<AudioClip>("sMorreu");
        ari = Resources.Load<AudioClip>("ari");
        Grab = Resources.Load<AudioClip>("Grab");
        nota = Resources.Load<AudioClip>("nota");
        tiro = Resources.Load<AudioClip>("tiro");
        fire = Resources.Load<AudioClip>("fire");
        mark = Resources.Load<AudioClip>("mark");
        gxp = Resources.Load<AudioClip>("gxp");
        pistol = Resources.Load<AudioClip>("pistol");
        aero = Resources.Load<AudioClip>("aero");
        aeroShot = Resources.Load<AudioClip>("aeroShot");
        stk = Resources.Load<AudioClip>("stk");
        telefone = Resources.Load<AudioClip>("telefone");
        zipada = Resources.Load<AudioClip>("zipada");
        ss = Resources.Load<AudioClip>("ss");
        oof = Resources.Load<AudioClip>("oof");
        uuhh = Resources.Load<AudioClip>("uuhh");
        tufao = Resources.Load<AudioClip>("tufao");
        standed = Resources.Load<AudioClip>("standed");
        ultready = Resources.Load<AudioClip>("ultready");
        ultimato = Resources.Load<AudioClip>("ultimato");
        launch = Resources.Load<AudioClip>("launch");
        load = Resources.Load<AudioClip>("load");
        kill = Resources.Load<AudioClip>("kill");
        canho = Resources.Load<AudioClip>("canho");
        explo = Resources.Load<AudioClip>("explo");
        jason = Resources.Load<AudioClip>("jason");
        lvup = Resources.Load<AudioClip>("lvUp");

        asr = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip){
        switch(clip){
            case "sPulo":
                asr.PlayOneShot(sPulo);
                break;
            case "sLand":
                asr.PlayOneShot(sLand);
                break;
            case "sHit":
                asr.PlayOneShot(sHit);
                break;
            case "oof":
                asr.PlayOneShot(oof);
                break;
            case "uuhh":
                asr.PlayOneShot(uuhh);
                break;
            case "sMorreu":
                asr.PlayOneShot(sDie);
                break;
            case "ari":
                asr.PlayOneShot(ari);
                break;
            case "Grab":
                asr.PlayOneShot(Grab);
                break;
            case "nota":
                asr.PlayOneShot(nota);
                break;
            case "tiro":
                asr.PlayOneShot(tiro);
                break;
            case "fire":
                asr.PlayOneShot(fire);
                break;
            case "mark":
                asr.PlayOneShot(mark);
                break;
            case "gxp":
                asr.PlayOneShot(gxp);
                break;
            case "pistol":
                asr.PlayOneShot(pistol);
                break;
            case "aero":
                asr.PlayOneShot(aero);
                break;
            case "aeroShot":
                asr.PlayOneShot(aeroShot);
                break;
            case "stk":
                asr.PlayOneShot(stk);
                break;
            case "telefone":
                asr.PlayOneShot(telefone);
                break;
            case "zipada":
                asr.PlayOneShot(zipada);
                break;
            case "ss":
                asr.PlayOneShot(ss);
                break;
            case "standed":
                asr.PlayOneShot(standed);
                break;
            case "tufao":
                asr.PlayOneShot(tufao);
                break;
            case "ultready":
                asr.PlayOneShot(ultready);
                break;
            case "ultimato":
                asr.PlayOneShot(ultimato);
                break;
            case "launch":
                asr.PlayOneShot(launch);
                break;
            case "load":
                asr.PlayOneShot(load);
                break;
            case "kill":
                asr.PlayOneShot(kill);
                break;
            case "canho":
                asr.PlayOneShot(canho);
                break;
            case "explo":
                asr.PlayOneShot(explo);
                break;
            case "jason":
                asr.PlayOneShot(jason);
                break;
            case "gole":
                asr.PlayOneShot(Resources.Load<AudioClip>("gole"));
                break;
            case "papagaio":
                asr.PlayOneShot(Resources.Load<AudioClip>("papagaio"));
                break;
            case "ave":
                asr.PlayOneShot(Resources.Load<AudioClip>("ave"));
                break;
            case "pause":
                asr.PlayOneShot(Resources.Load<AudioClip>("pause"));
                break;
            case "resume":
                asr.PlayOneShot(Resources.Load<AudioClip>("resume"));
                break;
            case "skip":
                asr.PlayOneShot(Resources.Load<AudioClip>("skip"));
                break;
            case "firewall":
                asr.PlayOneShot(Resources.Load<AudioClip>("firewall"));
                break;
            case "lvup":
                asr.PlayOneShot(lvup);
                break;
            case "slc":
                asr.PlayOneShot(Resources.Load<AudioClip>("slc"));
                break;
            case "flw":
                asr.PlayOneShot(Resources.Load<AudioClip>("flw"));
                break;
            case "kh":
                asr.PlayOneShot(Resources.Load<AudioClip>("kh"));
                break;
            case "deflect1":
                asr.PlayOneShot(Resources.Load<AudioClip>("deflect1"));
                break;
            case "deflect2":
                asr.PlayOneShot(Resources.Load<AudioClip>("deflect2"));
                break;
            case "deflect3":
                asr.PlayOneShot(Resources.Load<AudioClip>("deflect3"));
                break;
            case "HE":
                asr.PlayOneShot(Resources.Load<AudioClip>("bigHE"));
                break;
            case "ME":
                asr.PlayOneShot(Resources.Load<AudioClip>("medHE"));
                break;


        }
    }
    public static void Som(string clipe, float volume = 1)
    {
        asr.PlayOneShot(Resources.Load<AudioClip>(clipe), volume);
    }
    
    
    // Update is called once per frame
    void Update()
    {
        asr.volume = pontuacao.somGeral;        
    }
}
