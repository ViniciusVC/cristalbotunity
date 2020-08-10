using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaControler : MonoBehaviour {

	public static string varStatusPorta; //"", "abrindo", "fechando"
	public float AnguloAtualPorta; //de -90 a 13.
	private float SomaAnguloPorta;

	private string NivelAtual;

	// Use this for initialization
	void Start () {
		varStatusPorta = ""; //"", "abrindo", "fechando"
		AnguloAtualPorta = -90.0f; //de -90 a 13.
		NivelAtual="";
	}
	
	private void AbrirPorta()
	{
		varStatusPorta = "abrindo";
		AudioControler.rodarSom = "PortaNave"; // "PortaNave","Cristal","SemEnergia"		
	}

	private void FecharPorta()
	{
		varStatusPorta = "fechando";
		AudioControler.rodarSom = "PortaNave"; // "PortaNave","Cristal","SemEnergia"		
		// float AnguloPorta = 10.0f;
		// //Vector3 NovaPosicaoPorta = new Vector3 (AnguloPorta, 90.0f, 90.0f);
		// objPortaNave.gameObject.transform.Rotate(new Vector3 (0.0f, 1.0f, 0.0f));
		AudioControler.rodarSom = "PortaNave"; // "PortaNave","Cristal","SemEnergia", "meteoro", "vooDaNave"
	}

	private void ControlaPortaNave()
	{
		//AnguloPorta = 103.0f;
		//objPortaNave.gameObject.transform.Rotate (new Vector3 (20, 0, 0));

		if(varStatusPorta=="abrindo"){
			//"", "abrindo", "fechando"
			if(AnguloAtualPorta<=13.0f){
				AnguloAtualPorta = AnguloAtualPorta + 1.0f;
				transform.Rotate(new Vector3 (0.0f, -1.0f, 0.0f));
			}else{
				varStatusPorta="";
			}	
		}else if(varStatusPorta=="fechando"){
			//"", "abrindo", "fechando"
			if(AnguloAtualPorta>=-90.0f){
				AnguloAtualPorta = AnguloAtualPorta -1.0f;
				transform.Rotate(new Vector3 (0.0f, 1.0f, 0.0f));
			}else{
				if(NivelAtual=="nivel1") {
					print("Indo para Nivel 2");
					varStatusPorta="";
					NaveControler.varStatusNave="nivel2";
					NivelAtual="nivel2";
				}else if(NivelAtual=="nivel2") {
					print("Indo para Nivel 3");
					varStatusPorta="";
					NaveControler.varStatusNave="nivel3";
					NivelAtual="nivel3";
				}else{
					varStatusPorta="";
				}
			}	
		}
	}

	// Update is called once per frame
	void Update () {
		ControlaPortaNave();		
	}
}
