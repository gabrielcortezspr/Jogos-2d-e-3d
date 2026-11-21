using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cavera : MonoBehaviour
{
	public float moveSpeed;
	//public float duracao;

	Rigidbody2D rb;

	nag target;
	Vector2 moveDirection;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		target = GameObject.FindObjectOfType<nag>();
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
		//Destroy (gameObject, duracao);
	}

	void Update()
	{
		transform.Translate(new Vector3(0.03f, 0.01f)) ; //kkkkkkkk ele passa o sarrafo e vai embora é o flash po vai dexa o trab sujo pramim

		float distanciaX, distanciaY, angulo;

		distanciaX = transform.position.x - target.transform.position.x;
		distanciaY = transform.position.y - target.transform.position.y;// sincronizadasso q

		angulo = Mathf.Atan(distanciaY / distanciaX); //acho q agora vai vo testa

		angulo = angulo * Mathf.Rad2Deg;


		if (distanciaX > 0)
		{
			angulo += 180;
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, angulo));
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name.Equals("nag")) 
		{
			Debug.Log("Hit!");
			//soundmanagero.PlaySound("sHit");
			//movimentamento.vida -= 10;
			//Destroy (gameObject);
		}
	}
}
