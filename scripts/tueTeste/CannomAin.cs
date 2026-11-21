using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannomAin : MonoBehaviour {
	
	
	private GameObject alvo;

	// Use this for initialization
	void Start () {
		alvo = FindObjectOfType<movimentamento>().gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		//if(GetComponent<CannonShoot>().ultimoTiro < GetComponent<CannonShoot>().delay && GetComponent<CannonShoot>().ultimoTiro != 0)
  //      {
		//	return;
  //      }
		float distanciaX, distanciaY, angulo;

		distanciaX = transform.position.x - alvo.transform.position.x;
		distanciaY = transform.position.y - alvo.transform.position.y;

		angulo = Mathf.Atan (distanciaY/distanciaX);

		angulo = angulo * Mathf.Rad2Deg;

		if (distanciaX < 0){
			angulo += 180;
		}	

		transform.rotation = Quaternion.Euler (new Vector3 (0, 0, angulo));	
	}
	
}
