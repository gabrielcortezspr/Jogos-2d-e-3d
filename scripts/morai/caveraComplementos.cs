using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caveraComplementos : MonoBehaviour
{
    CircleCollider2D circo;
    // Start is called before the first frame update
    void Start()
    {
        circo = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (circo.gameObject.name.Equals("Nagazaki"))
        {
            Debug.Log("dash");
            
        }
    }
}
