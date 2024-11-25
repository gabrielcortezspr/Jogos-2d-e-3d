using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    private Vector2 velocidade;
    public float delayX, delayY;
    public Transform player;
    public bool limites;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;
    public AudioSource normal;
    public AudioSource invertido;
            

    // Use this for initialization
    void Start()
    {
        normal.Play();
        invertido.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if(nag.dead == true)
        {
            normal.Pause();
            invertido.UnPause();
        }
        else
        {
            normal.UnPause();
            invertido.Pause();
        }
    }

    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.position.x, ref velocidade.x, delayX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.position.y, ref velocidade.y, delayY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if (limites == true)
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z)
            );
        }

    }
}