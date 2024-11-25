using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class gilete : MonoBehaviour
{
    public float cd;
    float cdt;
    public GameObject projetile;
    
    private void Update()
    {
        if(cdt == 0)
        {
            Instantiate(projetile, transform.position, transform.rotation);
            cdt = cd;

        }
        if(cdt > 0)
        {
            cdt -= Time.deltaTime;
        }
        if(cdt < 0)
        {
            cdt = 0;
        }
        
    }
}
