using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float delayInicial, coolDonw, spread;
    [HideInInspector]
    public float cdt;
    public GameObject projetil;
    public Transform offset;
    public string som;
    public float volume = 1;
    public bool needsIR;
    private void Start()
    {
        
    }
    private void Update()
    {
        if (needsIR)
        {
            if(GetComponent<inimigo>() == null)
            {
                if (!GetComponentInParent<inimigo>().inRange)
                {
                    return;
                }
            } 
            else if(!GetComponent<inimigo>().inRange)
            {
                return;
            }
            
        }
        if(delayInicial > 0)
        {
            delayInicial -= Time.deltaTime;
        }
        if(delayInicial <= 0)
        {
            if(cdt > 0)
            {
                cdt -= Time.deltaTime;
            }
            if(cdt <= 0)
            {
                if(offset == null)
                {
                    if(spread > 0)
                    {
                        float numero;
                        numero = Random.Range(-spread, spread);
                        Quaternion ze;
                        ze = Quaternion.Euler(transform.localEulerAngles.x,
                        transform.localEulerAngles.y,
                        transform.localEulerAngles.z + numero);


                        Instantiate(projetil, transform.position, ze);
                        cdt = coolDonw;
                        if (som != null)
                        {
                            soundmanagero.Som(som, volume);
                        }
                    }
                    else
                    {
                        Instantiate(projetil, transform.position, transform.rotation);
                        cdt = coolDonw;
                        if (som != null)
                        {
                            soundmanagero.Som(som, volume);
                        }
                    }

                }
                else
                {
                    if (spread > 0)
                    {
                        Instantiate(projetil, offset.position, Quaternion.Euler(transform.localEulerAngles.x,
                        transform.localEulerAngles.y,
                        transform.localEulerAngles.z + Random.Range(-spread, spread)));
                        cdt = coolDonw;
                            if (som != null)
                            {
                                soundmanagero.Som(som, volume);
                            }
                    }
                    else
                    {

                        Instantiate(projetil, offset.position, transform.rotation);
                        cdt = coolDonw;
                            if (som != null)
                            {
                                soundmanagero.Som(som, volume);
                            }
                    }

                }
            }
        }
    }
}
