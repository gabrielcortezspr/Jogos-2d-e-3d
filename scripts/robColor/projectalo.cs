using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectalo : MonoBehaviour
{
	public float moveSpeed;
	public float duracao;
	bool iFrame = false;
	//bool teleguiado = false;

	Rigidbody2D rb;

	Chin target;
	Vector2 moveDirection;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		target = GameObject.FindObjectOfType<Chin>();
		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
		rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
		Destroy(gameObject, duracao);
	}
	private void FixedUpdate()
	{
		//if (teleguiado)
		//{
		//	transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed / 2 * Time.deltaTime);
		//}
	}

	private void Awake()
	{
		Debug.Log("olha a pedra");

		//Invoke("pedrada", 2f);
	}

	void OnTriggerStay2D(Collider2D jurupinga)
	{
		if (jurupinga.gameObject.name.Equals("xin") && !iFrame)
		{
			Debug.Log("Hit!");
			

			
			
			
		}
		
	}
    private void OnCollisionEnter2D(Collision2D jurupinga)
    {
		if (jurupinga.gameObject.layer == 8)
		{
			Destroy(gameObject);
		}
	}

    //void pedrada()
    //{
    //	moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
    //	rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    //	//rb.velocity = Vector2.zero;
    //	//teleguiado = true;
    //	Debug.Log("cabeça de gelo");
    //}
}
