using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class NEXT : MonoBehaviour
{
    
    public Animator anim;
    public float transicao;
    public int matematica;

    void Update()
    {
        
    }
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            nextlvl();
        }
    }
    public void nextlvl()
    {
        StartCoroutine(loadlvl(SceneManager.GetActiveScene().buildIndex + matematica));//pega o codigo da cena atual e + 1

    }

    IEnumerator loadlvl(int levelIndex)
    {
        anim.SetTrigger("start");
        yield return new WaitForSeconds(transicao);
        SceneManager.LoadScene(levelIndex);
             
    }

}
