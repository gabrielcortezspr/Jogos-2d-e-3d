using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enerugy : MonoBehaviour
{
    public float maximum;
    public float current;
    public Image Mask;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        current = Chin.bateria;
        GetCurrentFill();
    }
    void GetCurrentFill()
    {
        float fiu = (float)current / (float)maximum;
        Mask.fillAmount = fiu;

    }
}
