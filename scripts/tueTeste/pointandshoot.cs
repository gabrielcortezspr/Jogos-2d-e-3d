using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointandshoot : MonoBehaviour
{
   
    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject bulletStart;

    public Animator standa; 
    private float ultimoTiro;
    public float recarga;


    public float bulletSpeed = 60.0f;

    private Vector3 target;


    float cdt = 0;
    float cd = 1f;

    // Use this for initialization
    void Start () {
        
        ultimoTiro = Time.time;
    }
    
    // Update is called once per frame
    void Update () {

        if (cdt > 0)
        {
            cdt -= Time.deltaTime;
        }
        if (cdt < 0)
        {
            cdt = 0;
        }
        if (cdt == 0)
            movimentamento.atirando = false;
        else
            movimentamento.atirando = true;

        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        

        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

    
        if(Time.time -ultimoTiro >= recarga && movimentamento.mana > 1){
        if(Input.GetMouseButton(0)){
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireBullet(direction, rotationZ);
            standa.SetTrigger("soco");
            soundmanagero.PlaySound("fire");
                movimentamento.mana -= FindObjectOfType<movimentamento>().manaconsume;
                
            ultimoTiro = Time.time;
                cdt = 0.4f;
            }
        }
    }
    void fireBullet(Vector2 direction, float rotationZ){
        GameObject b = Instantiate(bulletPrefab) as GameObject;
        b.transform.position = bulletStart.transform.position;
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
