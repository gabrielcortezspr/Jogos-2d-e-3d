using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMan : MonoBehaviour
{
    private Vector2 velocidade;
    public float delayX, delayY;
    public Transform player;
    public bool limites;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;
    


    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
