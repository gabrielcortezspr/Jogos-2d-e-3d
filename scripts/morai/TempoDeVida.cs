using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoDeVida : MonoBehaviour
{
    public float tempoVida; public float tempoInicial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - tempoInicial >= tempoVida)
        {
            Destroy(gameObject);
        }
             
    }
}
