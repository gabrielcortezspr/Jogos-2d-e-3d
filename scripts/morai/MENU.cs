using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENU : MonoBehaviour
{
    public void fase1()
    {
        SceneManager.LoadScene(1);
    }
    public void fase2()
    {
        SceneManager.LoadScene(2);
    }
    public void fase3()
    {
        SceneManager.LoadScene(3);
    }
    public void fase5()
    {
        SceneManager.LoadScene(5);
    }
    public void quitar()
    {
        Application.Quit();
    }


}
