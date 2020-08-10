using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class solo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) 
	{
	// Quando este objeto colidir com 'is trigger' marcado, 
	// A variável 'other' recebe uma referência ao objeto colisor.

		if(other.gameObject.CompareTag("Tambor"))
		{
			// colidiu com um objeto com a tag 'Tambor'?
			print("Meteoro chegou ao solo.");
			//Random randNum = new Random();
			//print();
			//print();
			//Vector3 tamanhoMeteoro = new Vector3 (10.0f, 10.0f, 10.0f);
			//other.gameObject.transform.localScale = PorcentagemBarra;
			Vector3 NovaPosicaoMeteoro = new Vector3 (Random.Range(-15.0f, 10.0f), 16.0f, Random.Range(20.0f, 70.0f));
			//Vector3 NovaPosicaoMeteoro = new Vector3 (-15.0f, 16.0f, 70.0f);
			other.gameObject.transform.localPosition = NovaPosicaoMeteoro;
			// //other.gameObject.SetActive(false);
		}
	}
}
