using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControler : MonoBehaviour {

	public AudioSource fonteDeAudio;
	public AudioClip[] sonsDoJogo;
	
	public static string rodarSom; // "PortaNave","Cristal","SemEnergia"

	// Use this for initialization
	void Start () {
		//tocaSomPortaNave();
		//tocaSomCristal();
		//tocaSomSemEnergia();
		//tocarSom();
	}

	private void tocaSom(int varNumSom)
	{
	 	fonteDeAudio.clip = sonsDoJogo[varNumSom]; 
	 	fonteDeAudio.Play();
	}


	// private void tocaSomPortaNave(){
	// 	fonteDeAudio.clip = sonsDoJogo[0]; //SomDaPorta;
	// 	fonteDeAudio.Play();
	// }

	// private void tocaSomCristal()
	// {
	// 	//AudioClip SomDoCristal = sonsDoJogo[1];
	// 	fonteDeAudio.clip = sonsDoJogo[1]; // SomDoCristala;
	// 	fonteDeAudio.Play();
	// }

	// private void tocaSomSemEnergia()
	// {
	// 	//AudioClip SomSemEnergia = sonsDoJogo[2];
	// 	fonteDeAudio.clip = sonsDoJogo[2]; // SomSemEnergia;
	// 	fonteDeAudio.Play();
	// }


	// Update is called once per frame
	void Update () {
		if(rodarSom!=""){
			if(rodarSom=="PortaNave"){
				rodarSom="";			
				tocaSom(0); // Barulho abre porta da nave : sonsDoJogo[0];
			}else if(rodarSom=="SemEnergia"){
				rodarSom="";
				tocaSom(1);	// 	Beep : sonsDoJogo[1];
			}else if(rodarSom=="Cristal"){
				rodarSom="";				
				tocaSom(2); // Barulho cristal caindo : sonsDoJogo[2];		
			}else if(rodarSom=="Meteoro"){
				rodarSom="";				
				tocaSom(3); // Barulho cristal caindo : sonsDoJogo[2];		
			}else if(rodarSom=="VoodaNave"){
				rodarSom="";				
				tocaSom(4); // Barulho cristal caindo : sonsDoJogo[2];		
			}else{
				rodarSom="";
			}
		}
	}
}
