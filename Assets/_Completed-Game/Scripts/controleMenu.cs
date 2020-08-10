
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class controleMenu : MonoBehaviour {

	public GameObject ObjPainelMenu; // Menu principal do jogo.
	public GameObject ObjPainelDirecional; // Painel de controles.  
	public GameObject ObjPainelCreditos; // Painel com os créditos do jogo.
	public GameObject ObjPainelPlaneta; // Painel onde o jogador escolhe o cenario.
	public GameObject ObjPainelLingua; // Painel onde o jogador escolhe a lingua do jogo.

	public GameObject ObjCenarioMercurio;
	public GameObject ObjCenarioVenus;
	public GameObject ObjCenarioLua;
	public GameObject ObjCenarioMarte;
	public GameObject ObjCenarioPlutao;

	// public Text objTextBtJogar; // Botão de Jogar no menu principal
	// public Text objTextBtCreditos; // Botão de Creditos no menu principal
	// public Text objTextBtSair; // Botão de Sair do Jogo no menu principal
	// public Text objTextBtPlanetas; // Botão Escolher Planetas no menu principal
	// public Text objTextBtDirecao; // Botão de direção no menu principal

	public static bool estadoPainelMenu;
	public static bool estadoPainelDirecional;
	public static bool estadoPainelCreditos;
	public static bool estadoPainelPlaneta;
	public static bool estadoPainelLingua;
	public static string CenarioAtual;

	void Start()
	{
		estadoPainelMenu=false;
		estadoPainelDirecional=true;
		estadoPainelCreditos=false;
		estadoPainelPlaneta=false;
		CenarioAtual="Marte";
		//CenarioAtual="Mercurio","Venus","Lua","Marte","Plutao";
	}

	private void PainelMenuEsconde(){
		estadoPainelMenu=false;
		ObjPainelMenu.gameObject.SetActive(estadoPainelMenu);
	}

	public void PainelMenuMostra(){
		if(estadoPainelMenu){
			PainelMenuEsconde();
		}else{
			estadoPainelMenu=true;		
			ObjPainelMenu.gameObject.SetActive(estadoPainelMenu);
		} 
	}

	private void PainelPlanetaEsconde(){
		estadoPainelPlaneta=false;
		ObjPainelPlaneta.gameObject.SetActive(estadoPainelPlaneta);
	}

	public void PainelPlanetaMostra(){
		if(estadoPainelPlaneta){
			PainelPlanetaEsconde();
		}else{
			//Esconter menu principal.
			PainelMenuEsconde();
			//Mostrar menu planetas.
			estadoPainelPlaneta=true;
			ObjPainelPlaneta.gameObject.SetActive(estadoPainelPlaneta);
		} 
	}


	public void PanelDirecionalMostra(){
		if(estadoPainelDirecional){
			estadoPainelDirecional=false;
		}else{
			estadoPainelDirecional=true;			
		}
		ObjPainelDirecional.gameObject.SetActive(estadoPainelDirecional);
	}

	public void PanelCreditosMostra(){
		if(estadoPainelCreditos){
			estadoPainelCreditos=false;
		}else{
			estadoPainelCreditos=true;
		}
		PainelMenuMostra();
		ObjPainelCreditos.gameObject.SetActive(estadoPainelCreditos);
	}

	public void PanelLinguaMostra(){
		if(estadoPainelLingua){
			estadoPainelLingua=false;
		}else{
			estadoPainelLingua=true;
		}
		PainelMenuMostra();
		ObjPainelLingua.gameObject.SetActive(estadoPainelLingua);
	}

	public void MudouLingPort(){
		PlayerController.LinguaGame = "portugues";
		PanelLinguaMostra();
		// objTextBtJogar.text ="J2"; // Botão de Jogar no menu principal
		// objTextBtCreditos.text="C2"; // Botão de Creditos no menu principal
		// objTextBtSair.text="S2"; // Botão de Sair do Jogo no menu principal
		// objTextBtPlanetas.text="P2"; // Botão Escolher Planetas no menu principal
		// objTextBtDirecao.text="D2"; // Botão de direção no menu principal
	}
	public void MudouLingIngl(){
		PlayerController.LinguaGame = "ingles";
		PanelLinguaMostra();
		// objTextBtJogar.text ="J1"; // Botão de Jogar no menu principal
		// objTextBtCreditos.text="C1"; // Botão de Creditos no menu principal
		// objTextBtSair.text="S1"; // Botão de Sair do Jogo no menu principal
		// objTextBtPlanetas.text="P1"; // Botão Escolher Planetas no menu principal
		// objTextBtDirecao.text="D1"; // Botão de direção no menu principal
	}

	public void CenarioMercurioMostra(){
		//Esconder Menu principal.
		PainelPlanetaEsconde();
		//Abrir novo cenário.
		EsconderCenarios("Mercurio");
	}

	public void CenarioVenusMostra(){
		//Esconder Menu principal.
		PainelPlanetaEsconde();
		//Abrir novo cenário.
		EsconderCenarios("Venus");
	}

	public void CenarioLuaMostra(){
		//Esconder Menu principal.
		PainelPlanetaEsconde();
		//Abrir novo cenário.
		EsconderCenarios("Lua");
	}

	public void CenarioMarteMostra(){
		//Esconder Menu principal.
		PainelPlanetaEsconde();
		//Abrir novo cenário.
		EsconderCenarios("Marte");
	}

	public void CenarioPlutaoMostra(){
		//Esconder Menu principal.
		PainelPlanetaEsconde();
		//Abrir novo cenário.
		EsconderCenarios("Plutao");
	}

	private void EsconderCenarios(string NovoCenario){
		if(CenarioAtual!=NovoCenario){
			if(CenarioAtual=="Mercurio"){
				ObjCenarioMercurio.gameObject.SetActive(false);	
			}else if(CenarioAtual=="Venus"){
				ObjCenarioVenus.gameObject.SetActive(false);
			}else if(CenarioAtual=="Lua"){
				ObjCenarioLua.gameObject.SetActive(false);
			}else if(CenarioAtual=="Marte"){
				ObjCenarioMarte.gameObject.SetActive(false);
			}else if(CenarioAtual=="Plutao"){
				ObjCenarioPlutao.gameObject.SetActive(false);
			}else{
				print("ERRO - Nenhum Cenario escolhido. CenarioAtual=" + CenarioAtual);	
			}
			if(NovoCenario=="Mercurio"){
				ObjCenarioMercurio.gameObject.SetActive(true);	
			}else if(NovoCenario=="Venus"){
				ObjCenarioVenus.gameObject.SetActive(true);
			}else if(NovoCenario=="Lua"){
				ObjCenarioLua.gameObject.SetActive(true);
			}else if(NovoCenario=="Marte"){
				ObjCenarioMarte.gameObject.SetActive(true);
			}else if(NovoCenario=="Plutao"){
				ObjCenarioPlutao.gameObject.SetActive(true);
			}else{
				print("ERRO - Nenhum Cenario escolhido. NovoCenario=" + NovoCenario);	
			}
			CenarioAtual = NovoCenario;
		}
	}

	public void QuitGame(){
		Application.Quit();
	}

	public void butA(){
		print("Clicou no A");
		if(PlayerController.LetraMenuBut == "A"){
			PlayerController.LetraMenuBut = "";
		}else{
			PlayerController.LetraMenuBut = "A";
		}
	}

	public void butD(){
		print("Clicou no D");
		if(PlayerController.LetraMenuBut == "D"){
			PlayerController.LetraMenuBut = "";
		}else{
			PlayerController.LetraMenuBut = "D";
		}
	}

	public void butE(){
		print("Clicou no E");
				if(PlayerController.LetraMenuBut == "E"){
			PlayerController.LetraMenuBut = "";
		}else{
			PlayerController.LetraMenuBut = "E";
		}
	}

	public void butQ(){
		print("Clicou no Q");
		if(PlayerController.LetraMenuBut == "Q"){
			PlayerController.LetraMenuBut = "";
		}else{
			PlayerController.LetraMenuBut = "Q";
		}
	}

	public void butS(){
		print("Clicou no S");
		if(PlayerController.LetraMenuBut == "S"){
			PlayerController.LetraMenuBut = "";
		}else{
			PlayerController.LetraMenuBut = "S";
		}
	}

	public void butW(){
		print("Clicou no W");
		if(PlayerController.LetraMenuBut == "W"){
			PlayerController.LetraMenuBut = "";
		}else{
			PlayerController.LetraMenuBut = "W";
		}
	}

	public void butX(){
		print("Clicou no X");
		if(PlayerController.LetraMenuBut == "X"){
			PlayerController.LetraMenuBut = "";
		}else{
			PlayerController.LetraMenuBut = "X";
		}
	}

	public void butZ(){
		print("Clicou no Z");
		if(PlayerController.LetraMenuBut == "Z"){
			PlayerController.LetraMenuBut = "";
		}else{
			PlayerController.LetraMenuBut = "Z";
		}
	}
	
}