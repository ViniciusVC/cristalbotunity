using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Novo script para controlar todos os cristais soltos.

public class CristalControler : MonoBehaviour {
	
	public GameObject[] ObjCritaisSoltos; // Objeto 3D Cristal no terreno.

	public string TipoCristSouEu; // "A","B","C","D","E"

	
	// Inicialização da cena.
	void Start () {
		//TipoCristSouEu
		funcMudaCristal(TipoCristSouEu);
	}
	
	private void funcMudaCristal(string novoCristal){
		// Trocar tipo de cristal
		TipoCristSouEu=novoCristal;
		funcEsconderCristais();
		funcMostrarCristal(novoCristal);
	}

	void funcEsconderCristais(){
		// Esconder os cristais soltos.
		ObjCritaisSoltos[0].gameObject.SetActive(false);
		ObjCritaisSoltos[1].gameObject.SetActive(false);
		ObjCritaisSoltos[2].gameObject.SetActive(false);
		ObjCritaisSoltos[3].gameObject.SetActive(false);
		ObjCritaisSoltos[4].gameObject.SetActive(false);
	}

	private void funcMostrarCristal(string varNomeCristal){
		// AudioControler.rodarSom = "Cristal";
		print("varNomeCristal="+varNomeCristal);
		// Mostrar o cristal.
		if(varNomeCristal=="A"){
			ObjCritaisSoltos[0].gameObject.SetActive(true);
		}else if(varNomeCristal=="B"){
			ObjCritaisSoltos[1].gameObject.SetActive(true);
		}else if(varNomeCristal=="C"){
			ObjCritaisSoltos[2].gameObject.SetActive(true);
		}else if(varNomeCristal=="D"){
			ObjCritaisSoltos[3].gameObject.SetActive(true);
		}else if(varNomeCristal=="E"){
			ObjCritaisSoltos[4].gameObject.SetActive(true);
		}
	}

	private void trocaCristGarra(string cristal1Eu, string cristal2Robo){
		funcMudaCristal(cristal2Robo);
		PlayerController.carregandocristal=cristal1Eu;
		AudioControler.rodarSom = "Cristal";
	}

	void OnTriggerEnter(Collider other) 
	{
		// Quando este cristal colidir com o 'Player'(marcado), 
		if(other.gameObject.CompareTag("Player") && TipoCristSouEu!="")
		{
			//Vector3 positEfeito = other.gameObject.transform.localPosition();
			//Vector3 positEfeito = other.gameObject.transform.position;
			Vector3 positEfeito = new Vector3 (ObjCritaisSoltos[0].gameObject.transform.position.x,ObjCritaisSoltos[0].gameObject.transform.position.y+0.7f,ObjCritaisSoltos[0].gameObject.transform.position.z-0.6f);
			print("Player colidiu com cristal solto.");
			if(PlayerController.carregandocristal==""){
				AudioControler.rodarSom = "Cristal";
				print("Player não está carregando cristal.");
				funcEsconderCristais();
				PlayerController.carregandocristal=TipoCristSouEu;
				print("Pegou o cristal ["+TipoCristSouEu+"].");
				TipoCristSouEu="";
			}else if(PlayerController.carregandocristal=="A"){
				if(TipoCristSouEu=="A"){
					AudioControler.rodarSom = "Cristal";
					funcMudaCristal("C");
					PlayerController.carregandocristal="";
					FindObjectOfType<controleEfeitos>().GetComponent<controleEfeitos>().funcEfeitoCristal1(positEfeito);
				}else{
					trocaCristGarra(TipoCristSouEu, PlayerController.carregandocristal);
				}
			}else if(PlayerController.carregandocristal=="B"){
				if(TipoCristSouEu=="B"){
					AudioControler.rodarSom = "Cristal";
					funcMudaCristal("D");
					PlayerController.carregandocristal="";
					FindObjectOfType<controleEfeitos>().GetComponent<controleEfeitos>().funcEfeitoCristal1(positEfeito);
				}else{
					trocaCristGarra(TipoCristSouEu, PlayerController.carregandocristal);
				}
			}else if(PlayerController.carregandocristal=="D"){
				if(TipoCristSouEu=="C"){
					AudioControler.rodarSom = "Cristal";
					funcMudaCristal("E");
					PlayerController.carregandocristal="";
					FindObjectOfType<controleEfeitos>().GetComponent<controleEfeitos>().funcEfeitoCristal1(positEfeito);
				}else{
					trocaCristGarra(TipoCristSouEu, PlayerController.carregandocristal);
				}
			}else if(PlayerController.carregandocristal=="C"){
				if(TipoCristSouEu=="D"){
					AudioControler.rodarSom = "Cristal";
					funcMudaCristal("E");
					PlayerController.carregandocristal="";
					FindObjectOfType<controleEfeitos>().GetComponent<controleEfeitos>().funcEfeitoCristal1(positEfeito);
				}else{
					trocaCristGarra(TipoCristSouEu, PlayerController.carregandocristal);
				}
			}else{
				trocaCristGarra(TipoCristSouEu, PlayerController.carregandocristal);
				//print("### Player está carregando um cristal("+PlayerController.carregandocristal+"). ###");
				//funcMudaCristal(PlayerController.carregandocristal);	
			}	

		}
	}

	// Quando atualizar.
	void Update () {

	}

}