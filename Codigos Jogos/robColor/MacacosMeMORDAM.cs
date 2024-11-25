using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class MacacosMeMORDAM : MonoBehaviour
{
    public GameObject pedra;
    public float min;
    public float max;
    
    Transform player;
        float cdt;
    bool on;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Loop1());
        player = FindObjectOfType<Chin>().transform;
        on = false;

    }
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > transform.position.x + max || player.position.x < transform.position.x - max)
        {
            on = false;
        }
        else on = true;
        if(cdt > 0)
        {
            cdt -= Time.deltaTime;
        }if (cdt < 0)
        {
            cdt = 0;
        }
        if (cdt == 0 && on)
        {
            Instantiate(pedra, transform.position, pedra.transform.rotation);
            cdt = 5;
        }
    }
    //IEnumerator Loop1()
    //{
    //    if (on)
    //    {
    //    Instantiate(pedra, transform.position, pedra.transform.rotation);
    //    }
    //    yield return new WaitForSeconds(5);
    //    StartCoroutine(Loop2());

    //}
    //IEnumerator Loop2()
    //{
    //    if (on)
    //    {
    //    Instantiate(pedra, transform.position, pedra.transform.rotation);
    //    }
    //    yield return new WaitForSeconds(5);
    //    StartCoroutine(Loop1());
    //}
}
