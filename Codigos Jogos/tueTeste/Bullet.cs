using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Bullet : MonoBehaviour {
	mira alvo;
	public bool sovai;
	public GameObject fumo;
	public int bounces;
	public bool piercing;
	public float kb;
	public int damage;
	public float moveSpeed;
	public float duracao;
	bool iFrame = false;
	//bool teleguiado = false;

	Rigidbody2D rb;

	movimentamento target;
	Vector2 moveDirection;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		target = GameObject.FindObjectOfType<movimentamento>();
		FindClosestEnemy();
        if (sovai)
        {

			moveDirection = (alvo.transform.position - transform.position).normalized * moveSpeed;
        }
        else
        {

		moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        }
		rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);
		Destroy (gameObject, duracao);
	}
    private void FixedUpdate()
    {
		if(bounces <= 0)
        {
			Destroy(gameObject);
        }
		//if (teleguiado)
		//{
		//	transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed / 2 * Time.deltaTime);
		//}
	}
	void FindClosestEnemy()
	{
		float distanceToClosestEnemy = Mathf.Infinity;
		mira closestEnemy = null;
		mira[] allEnemies = GameObject.FindObjectsOfType<mira>();

		foreach (mira currentEnemy in allEnemies)
		{
			float distanceToEnemy = (currentEnemy.transform.position - transform.position).sqrMagnitude;
			if (distanceToEnemy < distanceToClosestEnemy)
			{
				distanceToClosestEnemy = distanceToEnemy;
				closestEnemy = currentEnemy;
			}
		}

		alvo = closestEnemy;


	}

	private void Awake()
    {
		
    }

    void OnTriggerStay2D (Collider2D col)
	{
		if (col.gameObject.name.Equals ("sonic") && !iFrame) {
			

			FindObjectOfType<movimentamento>().takedmg(damage, kb, transform.position);
			
			iFrame = true;
			Invoke("frame", 0.5f);
            if (!piercing)
            {
				Destroy(gameObject);
            }
		}
	}
    private void OnCollisionEnter2D(Collision2D col)
    {
		{
			if(col.gameObject.layer == 8)
            {
				bounces -= 1;
            }
			if (col.gameObject.name.Equals("sonic") && !iFrame)
			{
				Debug.Log("Hit!");
				

				FindObjectOfType<movimentamento>().takedmg(damage, kb, transform.position);

				iFrame = true;
				Invoke("frame", 0.5f);
				if (!piercing)
				{
					Destroy(gameObject);
				}
			}
		}
	}
    void frame()
    {
		iFrame = false;
		
    }
    private void OnDestroy()
    {
		Instantiate(fumo, transform.position, quaternion.identity);
		if(FindObjectOfType<movimentamento>().transform.position.x < transform.position.x + 55 && FindObjectOfType<movimentamento>().transform.position.x > transform.position.x - 55)
        {
		soundmanagero.PlaySound("explo");

        }
    }
}
