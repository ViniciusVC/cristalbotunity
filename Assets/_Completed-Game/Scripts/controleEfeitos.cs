using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controleEfeitos : MonoBehaviour {

	public GameObject ObjEfeitoCristal; // Objeto 3D Cristal no terreno.

	public Animator animaEfeitoCristal;

	// Use this for initialization
	void Start () {
		//animaEfeitoCristal.SetBool("brilhoCristal",false);		
	}

//funcEfeitoCristal(new Vector3(-0.08f, 0.94f, -4.23f));

	public void funcEfeitoCristal1(Vector3 NovoLocal){
		//ObjEfeitoCristal.gameObject.SetActive(true);
		ObjEfeitoCristal.transform.localPosition = NovoLocal;
		//animaEfeitoCristal.play("AnimEfeitoCristal1");
		//animaEfeitoCristal.SetBool("brilhoCristal",true);
		animaEfeitoCristal.SetTrigger("brilho");
		//Vector3 PorcentagemBarra = new Vector3 (FuncCalcBarra(10000,varTempo), 1.0f, 1.0f);
		//ObjBarraTempo.gameObject.transform.localScale = PorcentagemBarra;
	}
	public void funcEfeitoCristal2(Vector3 NovoLocal){
		//ObjEfeitoCristal.gameObject.SetActive(true);
		ObjEfeitoCristal.transform.localPosition = NovoLocal;
		//animaEfeitoCristal.play("AnimEfeitoCristal1");
		//animaEfeitoCristal.SetBool("brilhoCristal",true);
		animaEfeitoCristal.SetTrigger("RodaCristal");
		//Vector3 PorcentagemBarra = new Vector3 (FuncCalcBarra(10000,varTempo), 1.0f, 1.0f);
		//ObjBarraTempo.gameObject.transform.localScale = PorcentagemBarra;
	}
	public void funcEfeitoCristal3(Vector3 NovoLocal){
		//ObjEfeitoCristal.gameObject.SetActive(true);
		ObjEfeitoCristal.transform.localPosition = NovoLocal;
		//animaEfeitoCristal.play("AnimEfeitoCristal1");
		//animaEfeitoCristal.SetBool("brilhoCristal",true);
		animaEfeitoCristal.SetTrigger("BrilhaCristal");
		//Vector3 PorcentagemBarra = new Vector3 (FuncCalcBarra(10000,varTempo), 1.0f, 1.0f);
		//ObjBarraTempo.gameObject.transform.localScale = PorcentagemBarra;
	}
	

	// Update is called once per frame
	void Update () {
		
	}
}
