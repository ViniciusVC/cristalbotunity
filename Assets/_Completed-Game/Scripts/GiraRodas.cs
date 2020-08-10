using UnityEngine;
using System.Collections;

public class GiraRodas : MonoBehaviour {

	//public GameObject player;
	
	public static bool Movendo; //player speed

	public bool MovendoRodas;
	
	void Start (){
		MovendoRodas = true;
	}	

	void LateUpdate ()
	{
		MovendoRodas = Movendo;  // Input.GetAxis("Movendo");

		//Robo esta em movimento?
		if(MovendoRodas){
			//Girar rodas do Robo.
			//print("Girando a roda");
			transform.Rotate (new Vector3 (20, 0, 0));
		}
		//else{
			//print("parou a roda");
			//transform.Rotate (new Vector3 (0, 0, 0));
		//}
	}
}	