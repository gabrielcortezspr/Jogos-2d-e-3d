using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gerente : MonoBehaviour
{
    
    private void Awake()
    {
        
    }
    public static void Resetamento(int matematica)
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +matematica);
    }
    //public static IEnumerator Falecimento(int mat)
    //{
    //    yield return new WaitForSeconds(1.5f);
    //}
    
}
