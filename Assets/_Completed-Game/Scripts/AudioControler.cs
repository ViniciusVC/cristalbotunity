using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControler : MonoBehaviour {

	public AudioSource fonteDeAudio; //ERRO
	public AudioClip[] sonsDoJogo; // Lista de sons "Porta_Nave","semBateriaAiff","cristal","MeteoroBateuAiff","VooDaNaveWav"
	
	public static string rodarSom; // Estado do audioControler ("","PortaNave","Cristal","SemEnergia").

	public static bool somLigado; // Tocar ou não sons (true, false).
	
	void Start () {
		rodarSom=""; // Iniciar variavel rodaSom ("","PortaNave","Cristal","SemEnergia").
		somLigado=true; // Iniciar somLigado.
		// if(somLigado!=true){
		//  	print("########### Iniciando somLigado");
		// 	somLigado=false; // Iniciar somLigado.
		// }
	}

	public void ligaSom(){
		if(somLigado){
			somLigado=false;
		}else{
			somLigado=true;			
		}
	}

	private void tocaSom(int varNumSom)
	{
	 	fonteDeAudio.clip = sonsDoJogo[varNumSom]; //ERRO
	 	fonteDeAudio.Play(); //ERRO
	}


	void Update () {
		
		if(rodarSom!=""){
			print("!!!!!!!!!!! rodarSom="+rodarSom.ToString()+"!!!!!!!!!!!!!!!!!!!1");
			if(somLigado==true){
				print("########### somLigado==true");
				if(rodarSom=="PortaNave"){
					rodarSom="";			
					tocaSom(0); // Barulho abre porta da nave : sonsDoJogo[0];
				}else if(rodarSom=="SemEnergia"){
					rodarSom="";
					tocaSom(1);	// 	Beep SemBateria.aiff : sonsDoJogo[1];
				}else if(rodarSom=="Cristal"){
					rodarSom="";				
					tocaSom(2); // Barulho cristal : sonsDoJogo[2];		
				}else if(rodarSom=="Meteoro"){
					rodarSom="";				
					tocaSom(3); // Barulho de MeteoroBateu.Aiff : sonsDoJogo[3];
				}else if(rodarSom=="VoodaNave"){
					rodarSom="";				
					tocaSom(4); // Barulho Voo da Nave : sonsDoJogo[4];		
				}else{
					rodarSom="";
				}
			}else{
				print("########### somLigado==false");
				// Som desligado pelo jogador.
				rodarSom="";
			}
		}
	}
}
