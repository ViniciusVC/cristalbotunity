using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script pasra controlar cristais no Laboratorio.

public class CristalLabControler : MonoBehaviour {

	public GameObject[] ObjCritaisLab; // Objeto 3D Cristal Laboratorio.

	public string jaTenhoCristal;
	
	public static bool LimpaCristLab;

	// Use na inicialização da cena.
	void Start () {
		//funcEsconderCristais();
	}

	void funcEsconderCristais(){
		// Esconder cristais do laboratorio.
		ObjCritaisLab[0].gameObject.SetActive(false);
		ObjCritaisLab[1].gameObject.SetActive(false);
		ObjCritaisLab[2].gameObject.SetActive(false);
		ObjCritaisLab[3].gameObject.SetActive(false);
		ObjCritaisLab[4].gameObject.SetActive(false);
		jaTenhoCristal="";
		PlayerController.LimpaCristais = PlayerController.LimpaCristais - 1;
		//print("LimpaCristais="+PlayerController.LimpaCristais.ToString());
	}

	private void funcMostrarCristal(string numObJCris){
		AudioControler.rodarSom = "Cristal";
		// print("numObJCris="+numObJCris);
		// // Esconder cristais do laboratorio.
		if(numObJCris=="A"){
			ObjCritaisLab[0].gameObject.SetActive(true);
			PlayerController.Pontos = PlayerController.Pontos + 10; 
		}else if(numObJCris=="B"){
			ObjCritaisLab[1].gameObject.SetActive(true);
			PlayerController.Pontos = PlayerController.Pontos + 10;
		}else if(numObJCris=="C"){
			ObjCritaisLab[2].gameObject.SetActive(true);
			PlayerController.Pontos = PlayerController.Pontos + 25;
		}else if(numObJCris=="D"){
			ObjCritaisLab[3].gameObject.SetActive(true);
			PlayerController.Pontos = PlayerController.Pontos + 25;
		}else if(numObJCris=="E"){
			ObjCritaisLab[4].gameObject.SetActive(true);
			PlayerController.Pontos = PlayerController.Pontos + 55;
		}
	}

	void OnTriggerEnter(Collider other) 
	{
	// Quando este objeto colidir com 'is trigger' marcado, 
	// A variável 'other' recebe uma referência ao objeto colisor.
		if(other.gameObject.CompareTag("Player"))
		{
			// colidiu com um objeto com a tag 'Player'.
			if(jaTenhoCristal==""){
				// Aqui já tem um cristal. Tem espaço para um cristal.
				if(PlayerController.carregandocristal!=""){
					Vector3 positEfeito = new Vector3 (gameObject.transform.position.x,gameObject.transform.position.y+2.0f,gameObject.transform.position.z);
					FindObjectOfType<controleEfeitos>().GetComponent<controleEfeitos>().funcEfeitoCristal3(positEfeito);
					
					PlayerController.countCristais = PlayerController.countCristais + 1;
					//print("Colocar cristal no laboratório.");
					jaTenhoCristal=PlayerController.carregandocristal;
					PlayerController.carregandocristal="";
					funcMostrarCristal(jaTenhoCristal);
				}else{	
					// PlayerController.countCristais = PlayerController.countCristais + 1;
					// jaTenhoCristal="B";
					// funcMostrarCristal(jaTenhoCristal);
					// print("Coloque um cristal aqui no laboratorio.");
				}
			}
		}
	}


	void Update () {
		if(PlayerController.LimpaCristais > 0){
			//LimpaCristLab=false;
			funcEsconderCristais();
			//print("!!!!!!!!!!!!!!!!  LimpaCristLab==TRUE !!!!!!!!!!!!");	
		}else{
			//print("!!!!!!!!!!!!!!!!  LimpaCristLab==FALSE !!!!!!!!!!!!");	
		}
	}

}
