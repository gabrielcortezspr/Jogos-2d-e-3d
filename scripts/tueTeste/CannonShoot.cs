using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour {
	public float delay;
	ParticleSystem fumo;
	
	public bool canhao;
	public Vector3 detectionRange;
	public float tempoRecarga;
	public float ultimoTiro;
	public GameObject projetil;
	
	public float rotSpeed;
	
	public float tempo;
	public float grauIniciaU;
	public bool gira;


	// Use this for initialization
	void Start () {
		
		fumo = GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
        if (gira)
        {
			girarira();
        }
		if (FindObjectOfType<movimentamento>().transform.position.x < transform.position.x + detectionRange.x && FindObjectOfType<movimentamento>().transform.position.x > transform.position.x - detectionRange.x &&
			FindObjectOfType<movimentamento>().transform.position.y < transform.position.y + detectionRange.y && FindObjectOfType<movimentamento>().transform.position.y > transform.position.y - detectionRange.y)
		{
			
        }
        else
        {
			return;
        }
		if(ultimoTiro > 0)
        {
			ultimoTiro -= Time.deltaTime;

        }
		if(ultimoTiro < 0)
        {
			ultimoTiro = 0;
        }
		if (ultimoTiro == 0){
			Instantiate (projetil, transform.position, transform.rotation);
			fumo.Play();
			soundmanagero.PlaySound("canho");
			ultimoTiro = tempoRecarga;
		}
        if (canhao)	
        {
			if (ultimoTiro < 0.6f)
			{

			GetComponent<SpriteRenderer>().color = new Color(1f, 0.3f, 0.3f, 1);
			return;
			}
			else
			{
			GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
			}

        }
	}
	float tempoTimer;
		bool mais;
	
	void girarira()
    {
		
		if(tempoTimer > 0)
        {
			tempoTimer -= Time.deltaTime;
        }
		if(tempoTimer < 0)
        {
			tempoTimer = 0;
        }
        if (tempoTimer == 0)
        {
			tempoTimer = tempo;
			mais = !mais;
        }
        if (mais)
        {
			grauIniciaU -= Time.deltaTime * rotSpeed;
			transform.rotation = Quaternion.Euler(0, 0, grauIniciaU);
		}
        else
        {
			grauIniciaU += Time.deltaTime * rotSpeed;
			transform.rotation = Quaternion.Euler(0, 0, grauIniciaU);
		}
	}
	
    private void OnDrawGizmos()
    {
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, transform.position + Vector3.right * detectionRange.x);
		Gizmos.DrawLine(transform.position, transform.position + Vector3.up * detectionRange.y);
	}
}
