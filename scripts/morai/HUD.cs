using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD instance;
    public GameObject bang;
    public Animator a;
    public GameObject crossfadeS;
    public Animator aCrossfadeS;
    
    void Start()
    {
        instance = this;
    }
    public void bangar()
    {
        a.SetTrigger("tec");
    }
    public void crossfadeStart()
    {
        crossfadeS.SetActive(true);
    }
}
