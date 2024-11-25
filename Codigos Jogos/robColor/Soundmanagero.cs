using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanagero : MonoBehaviour
{
    public static AudioClip bateria, morte;
    static AudioSource src;
    // Start is called before the first frame update
    void Start() 
    {
        bateria = Resources.Load<AudioClip> ("bateria");
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound (string clip)
    {
        switch (clip) { 
            case "bateria":
                src.PlayOneShot(bateria);
                break;
            case "morte":
                src.PlayOneShot(morte);
                break;
        }
    }
}
