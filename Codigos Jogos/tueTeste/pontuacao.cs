using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class pontuacao : MonoBehaviour
{
    
    public bool easy = false;
    public static bool hardware = false;
    public static float somMusica =1;
    public static float somGeral =1;
    bool calmela;
    public static int chaves;


    public static pontuacao instance;
    public GameObject morreu;
    public GameObject venceu;
    public GameObject setings;
    public GameObject basicos;
    public GameObject pausemenu;
    public GameObject mp;
    public GameObject cansaso;
    public TextMeshProUGUI amount;
    [Header("habilidades")]
    bool canSpend;
    
    public GameObject habilidades;
    public TextMeshProUGUI Sps;
    public TextMeshProUGUI força;
    public TextMeshProUGUI velocidade;
    public TextMeshProUGUI alcance;
    public TextMeshProUGUI defesa;
    bool spending;

    bool pause;

    movimentamento soni;



    
    void Start()
    {
        soni = FindObjectOfType<movimentamento>();
        instance = this;
        DontDestroyOnLoad(this);
        
        
        calmela = false;
        if(FindObjectOfType<movimentamento>().haveStand == false)
        {
            mp.SetActive(false);
        }
        else
        {
            mp.SetActive(true);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if(pausemenu == null)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            Time.timeScale = 5;
        }
        if (Input.GetKeyUp(KeyCode.BackQuote))
        {
            Time.timeScale = 1;
        }
        if (Input.GetKey(KeyCode.BackQuote))
        {
            return;
        }
        if (pause)
        {
            Time.timeScale = 0; if (!spending)
            {

            pausemenu.SetActive(true);
            }
        }
        else
        {
            Time.timeScale = 1; if (!spending)
            {

            pausemenu.SetActive(false);
               
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !pause)
        {
            //soundmanagero.PlaySound("pause");
            pause = true;
            //pausemenu.SetActive(true);
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && pause)
        {
            //soundmanagero.PlaySound("resume");
            pause = false;
            //pausemenu.SetActive(false);
        }

        if(soni != null)
        {
            if(soni.chaostate > 0)
            {
                cansaso.SetActive(true);
                amount.text = soni.chaostate.ToString("F2");
                

            }
            else
            {
                cansaso.SetActive(false);
            }
        }

    }
    private void FixedUpdate()
    {
        

        
    }
    public void resume()
    {
        
        soundmanagero.PlaySound("resume");
        pause = false;
        pausemenu.SetActive(false);
        Time.timeScale = 1;
    }

    
    public void hard()
    {
        soundmanagero.PlaySound("jason");
        hardware = !hardware;
    }
    public void ez()
    {
        soundmanagero.PlaySound("gxp");
        easy = !easy;
    }
    public void volumeMusica(float volume)
    {
        somMusica = volume;
    }
    public void volumeGeral(float volume2)
    {
        somGeral = volume2;
    }
    public void settings()
    {
        soundmanagero.PlaySound("skip");
        setings.SetActive(true);
        basicos.SetActive(false);
    }
    public void voltar()
    {
        soundmanagero.PlaySound("skip");
        setings.SetActive(false);
        basicos.SetActive(true);
    }
    public void spoil()
    {
        if(FindObjectOfType<movimentamento>().haveStand == true)
        {
            mp.SetActive(true);
        }
    }
    

    public void morrestes()
    {
        
        morreu.SetActive(true);
    }
    IEnumerator rapido()
    {
        yield return new WaitForSeconds(3f);
        RestartGame();
    }
    public void ganhastes()
    {
        
    }
    public void RestartGame()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        
        SceneManager.LoadScene(index);
    }
    public void qit()
    {
        Application.Quit();
    }
    public void loadlv(int index)
    {
        StartCoroutine(ldlv(index));
    }
    public IEnumerator ldlv(int index)
    {
        soundmanagero.PlaySound("skip");
        PlayerPrefs.SetInt("checkpoint", 0);
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(index);

    }
    #region Atributos
    public void Habilidades()
    {
        pausemenu.SetActive(false);
        if(habilidades == null)
        {
            return;
        }
        spending = true;
        habilidades.SetActive(true);
        força.text = PlayerPrefs.GetInt("str").ToString() + " / 3";
        velocidade.text = PlayerPrefs.GetInt("spd").ToString() + " / 3";
        alcance.text = PlayerPrefs.GetInt("range").ToString() + " / 3";
        defesa.text = PlayerPrefs.GetInt("def").ToString() + " / 3";
        Sps.text = "[" + PlayerPrefs.GetInt("sp").ToString() + "] Pontos de atributo disponiveis";
    }
    public void HabilidadesBack()
    {
        pausemenu.SetActive(true);
        if (habilidades == null)
        {
            return;
        }
        habilidades.SetActive(false);
        spending = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StrAdd()
    {
        if (PlayerPrefs.GetInt("sp") > 0 && (PlayerPrefs.GetInt("str")) < 3)
        {
            PlayerPrefs.SetInt("str", PlayerPrefs.GetInt("str") + 1);
            PlayerPrefs.SetInt("sp", PlayerPrefs.GetInt("sp") - 1);
            força.text = PlayerPrefs.GetInt("str").ToString() + " / 3";
            Sps.text = "[" + PlayerPrefs.GetInt("sp").ToString() + "] Pontos de atributo disponiveis";
        }
    }
    public void StrSub()
    {
        if (PlayerPrefs.GetInt("str") > 0)
        {
            PlayerPrefs.SetInt("str", PlayerPrefs.GetInt("str") - 1);
            PlayerPrefs.SetInt("sp", PlayerPrefs.GetInt("sp") + 1);
            força.text = PlayerPrefs.GetInt("str").ToString() + " / 3";
            Sps.text = "[" + PlayerPrefs.GetInt("sp").ToString() + "] Pontos de atributo disponiveis";
        }
    }
    public void SpdAdd()
    {
        if (PlayerPrefs.GetInt("sp") > 0 && (PlayerPrefs.GetInt("spd")) < 3)
        {
            PlayerPrefs.SetInt("spd", PlayerPrefs.GetInt("spd") + 1);
            PlayerPrefs.SetInt("sp", PlayerPrefs.GetInt("sp") - 1);
            velocidade.text = PlayerPrefs.GetInt("spd").ToString() + " / 3";
            Sps.text = "[" + PlayerPrefs.GetInt("sp").ToString() + "] Pontos de atributo disponiveis";
        }
    }
    public void SpdSub()
    {
        if (PlayerPrefs.GetInt("spd") > 0)
        {
            PlayerPrefs.SetInt("spd", PlayerPrefs.GetInt("spd") - 1);
            PlayerPrefs.SetInt("sp", PlayerPrefs.GetInt("sp") + 1);
            velocidade.text = PlayerPrefs.GetInt("spd").ToString() + " / 3";
            Sps.text = "[" + PlayerPrefs.GetInt("sp").ToString() + "] Pontos de atributo disponiveis";
        }
    }
    public void RangeAdd()
    {
        if (PlayerPrefs.GetInt("sp") > 0 && (PlayerPrefs.GetInt("range"))< 3)
        {
            PlayerPrefs.SetInt("range", PlayerPrefs.GetInt("range") + 1);
            PlayerPrefs.SetInt("sp", PlayerPrefs.GetInt("sp") - 1);
            alcance.text = PlayerPrefs.GetInt("range").ToString() + " / 3";
            Sps.text = "[" + PlayerPrefs.GetInt("sp").ToString() + "] Pontos de atributo disponiveis";
        }
    }
    public void RangeSub()
    {
        if (PlayerPrefs.GetInt("range") > 0)
        {
            PlayerPrefs.SetInt("range", PlayerPrefs.GetInt("range") - 1);
            PlayerPrefs.SetInt("sp", PlayerPrefs.GetInt("sp") + 1);
            alcance.text = PlayerPrefs.GetInt("range").ToString() + " / 3";
            Sps.text = "[" + PlayerPrefs.GetInt("sp").ToString() + "] Pontos de atributo disponiveis";
        }
    }
    public void defAdd()
    {
        if (PlayerPrefs.GetInt("sp") > 0 && (PlayerPrefs.GetInt("def")) < 3)
        {
            PlayerPrefs.SetInt("def", PlayerPrefs.GetInt("def") + 1);
            PlayerPrefs.SetInt("sp", PlayerPrefs.GetInt("sp") - 1);
            defesa.text = PlayerPrefs.GetInt("def").ToString() + " / 3";
            Sps.text = "[" + PlayerPrefs.GetInt("sp").ToString() + "] Pontos de atributo disponiveis";
        }
    }
    public void defSub()
    {
        if (PlayerPrefs.GetInt("def") > 0)
        {
            PlayerPrefs.SetInt("def", PlayerPrefs.GetInt("def") - 1);
            PlayerPrefs.SetInt("sp", PlayerPrefs.GetInt("sp") + 1);
            defesa.text = PlayerPrefs.GetInt("def").ToString() + " / 3";
            Sps.text = "[" + PlayerPrefs.GetInt("sp").ToString() + "] Pontos de atributo disponiveis";
        }
    }
    #endregion



}
