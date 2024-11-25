using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class inicio : MonoBehaviour
{
    public bool Q = true;
    public bool E = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        especial();
        especial2();
    }
    void especial()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Q)
        {
            Debug.Log("Q");
            StartCoroutine(cd(3));
        }
    }
    void especial2()
    {
        if (Input.GetKeyDown(KeyCode.E) && E)
        {
            Debug.Log("E lançado");
            StartCoroutine(cd2(5));
        }
    }
    IEnumerator cd(float cooldown)
    {
        {
            //bool do cooldown = false;
            Q = false;
            yield return new WaitForSeconds(cooldown);
            Q = true;
            //bool do cooldown = true;
        }
    }
    IEnumerator cd2(float cooldown)
    {
        {
            //bool do cooldown = false;
            E = false;
            yield return new WaitForSeconds(cooldown);
            E = true;
            //bool do cooldown = true;
        }
    }
}
