using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveControler : MonoBehaviour {


	public static string varStatusNave; //"", "nivel1", "nivel2", "nivel2"
	private float posicaoZAtual; //de -6.95f, 10.0f, 20,0.
	private float posicaoYAtual; //0.4f

	private float SomaAngulo;

	// Use this for initialization
	void Start () {
		varStatusNave = ""; //varStatusNave=("", "nivel1","nivel2","nivel3")
		posicaoZAtual = -26f;//-10f; //de -6.95f.
		posicaoYAtual = 3.0f;
	}

	private void ControlaNave()
	{
		if(varStatusNave=="nivel1"){
			print("naveControle.ControlaNave - varStatusNave==nivel1");
			//Deslocar nave até o primeiro nivel da fase. varStatusNave=("", "nivel1","nivel2","nivel3")
			if(posicaoZAtual<=-7.0f){// Deslocamento para traz, até a posição Z=7.0f
				FuncSubindo();
			}else if(posicaoYAtual>0.9f){
				// Altura - descer até y=0.9f
				FuncAterriza();
			}else{
				FuncAbrirPorta();
				varStatusNave="";
			}

		}else if(varStatusNave=="nivel2"){
			print("naveControle.ControlaNave - varStatusNave==nivel2");
			//Deslocar nave até o segundo nivel da fase. varStatusNave=("", "nivel1","nivel2","nivel3")
			if(posicaoZAtual<=28.0f){ // Deslocamento para traz, até a posição Z=7.0f
				FuncSubindo();
			}else if(posicaoYAtual>2.9f){
				// Altura - descer até y= 2.9f
				FuncAterriza();
			}else{
				FuncAbrirPorta();
				varStatusNave="";
			}	
		}else if(varStatusNave=="nivel3"){
			print("naveControle.ControlaNave - varStatusNave==nivel3");
			//Deslocar nave até o terceiro nivel da fase. varStatusNave=("", "nivel1","nivel2","nivel3")
			if(posicaoZAtual<=60.0f){ // Deslocamento para traz, até a posição Z=50.0f
				FuncSubindo();
			}else if(posicaoYAtual>0.9f){ // Altura - descer até y= 0.9f
				FuncAterriza();
			}else{
				FuncAbrirPorta();
				varStatusNave="";
			}
		}

	}
	private void FuncSubindo(){
		//AudioControler.rodarSom = "VoodaNave";
		posicaoZAtual = posicaoZAtual + 0.1f; // Soma 0.1 a distancia tual.
		if(posicaoYAtual<4.0f){ // Altura limite do voo é 4.0f
			posicaoYAtual = posicaoYAtual + 0.1f; // Somo 0.1 a ALTURA atual.
		}
		transform.localPosition = new Vector3 (-10.78f, posicaoYAtual, posicaoZAtual);
	}

	private void FuncAterriza(){
		posicaoYAtual = posicaoYAtual - 0.1f; // Diminui p.i da ALTURA atual.
		transform.localPosition = new Vector3 (-10.78f, posicaoYAtual, posicaoZAtual);
	}

	private void FuncAbrirPorta()
	{
		PortaControler.varStatusPorta = "abrindo"; //"", "abrindo", "fechando"
		AudioControler.rodarSom = "PortaNave"; // "PortaNave","Cristal","SemEnergia"		
	}

	// Update is called once per frame
	void Update () {
		if(varStatusNave!=""){
			ControlaNave();
		}	
	}
}
