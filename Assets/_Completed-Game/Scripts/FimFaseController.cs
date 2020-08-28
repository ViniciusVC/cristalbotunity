using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FimFaseController : MonoBehaviour {

	public GameObject ObjPaineGanhou; // Painel com mensagem fim de jogo, ganhou.
	public GameObject ObjPainePerdeu; // Painel com mensagem fim de jogo, perdeu. 

	public Image ObjImgTrofeu1; //Imagem do trofeu
	public Image ObjImgTrofeu2; //Imagem do trofeu
	public Image ObjImgTrofeu3; //Imagem do trofeu

	// public Image ObjImgRoboTriste; //Imagem do trofeu

	//private bool estadoFimFase;
	public Text objTxtGanhou;
	public Text objTxtPerdeu;
	public Text TxtBtPerdeu;
	public Text TxtBtGanhou;

	void Start () {
		//estadoFimFase=false;
	}
	
	public void PerdeuFimFase(string textoFinal, string textoBt){
			Time.timeScale=1;
			if(textoFinal==""){
				textoFinal="Perdeu[lose]";
			}
			if(textoBt==""){
				textoBt="Voltar[Retun]";
			}
			ObjPainePerdeu.gameObject.SetActive(true);
			objTxtPerdeu.text = textoFinal;
			TxtBtPerdeu.text = textoBt;
	}

	public void GanhoFimFase(string textoFinal, string textoBt, int patente){
			Time.timeScale=1;
			if(textoFinal==""){
				textoFinal="Parabéns![Congratulations!]";
			}
			if(textoBt==""){
				textoBt="Voltar[Retun]";
			}
			ObjPaineGanhou.gameObject.SetActive(true);
			objTxtGanhou.text = textoFinal;
			TxtBtGanhou.text = textoBt;
			if(patente>2){
				// Pontuação máxima.
				ObjImgTrofeu1.gameObject.SetActive(true);
				ObjImgTrofeu2.gameObject.SetActive(true);
				ObjImgTrofeu3.gameObject.SetActive(true);
			}else if(patente>1){
				ObjImgTrofeu1.gameObject.SetActive(true);
				ObjImgTrofeu2.gameObject.SetActive(true);
				ObjImgTrofeu3.gameObject.SetActive(false);
			}else if(patente>0){
				// Pontuação minima.
				ObjImgTrofeu1.gameObject.SetActive(true);
				ObjImgTrofeu2.gameObject.SetActive(false);
				ObjImgTrofeu3.gameObject.SetActive(false);
			}
	}

	// public void MostraFimFase(){
	// 	if(estadoFimFase==true){
	// 		estadoFimFase=false;
	// 		ObjPainelCreditos.gameObject.SetActive(estadoFimFase);
	// 	}else{
	// 		estadoFimFase=true;
	// 		ObjPaineFimFase.gameObject.SetActive(estadoFimFase);
	// 		winText.text = VerificaLingua("Parabéns!\nDesafio concuido.\nExplore outros planetas. Pontos:"+Pontos.ToString(),"Congratulations!\nChallenge met.\nExplore other planets. Score:"+Pontos.ToString());
	// 		TxtCreditosBtVolta.text = VerificaLingua("Voltar","Return");
	// 	}
	// }

	// // Update is called once per frame
	// void Update () {
		
	// }

}
