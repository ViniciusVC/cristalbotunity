using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraPlayer : MonoBehaviour {

	public GameObject player;
	
	public static bool Movendo; //player speed

	public bool GirandoRobo;
	
	void Start (){
		GirandoRobo = true;
	}	

	void LateUpdate ()
	{
		GirandoRobo = Movendo;  // Input.GetAxis("Movendo");

		//Robo esta em movimento?
		if(GirandoRobo){
			//Girar rodas do Robo.
			print("Girando a roda");
			transform.Rotate (new Vector3 (20, 0, 0));
		}else{
			print("parou a roda");
			//transform.Rotate (new Vector3 (0, 0, 0));
		}
	}
}
